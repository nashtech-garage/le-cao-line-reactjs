import type { FormInstance } from 'antd';
import { Button, Checkbox, Col, Divider, Form, Row, Space } from 'antd';
import { calculateSize } from 'helper/Func/function';

import { MinusCircleFilled, PlusOutlined } from '@ant-design/icons';
import { ProFormSelect, ProFormSwitch } from '@ant-design/pro-components';
import type { CheckboxChangeEvent } from 'antd/lib/checkbox';
import Editor from 'components/Editor';
import { MAP_HEURISTIC_LEVEL, MAP_HEURISTIC_LEVEL_ID } from 'constants/exam';
import type { FC } from 'react';
import { useEffect } from 'react';
const { Item, List } = Form;

interface Props {
  formField: any;
  formRef: FormInstance;
  onSubmit?: any;
  initialValues?: any;
  onCancel?: any;
}

const TemplateFormFieldMultipleChoiceQuestion: FC<Props> = ({
  formField,
  formRef,
  onSubmit,
  initialValues,
  onCancel,
}) => {
  useEffect(() => {
    if (formRef && initialValues && Object.keys(initialValues).length > 0) {
      formRef.resetFields();
    }
  }, [formRef, initialValues]);

  const mapHeuristicLevelOptions = Object.keys(MAP_HEURISTIC_LEVEL).map((level: string) => ({
    label: MAP_HEURISTIC_LEVEL[level],
    value: MAP_HEURISTIC_LEVEL_ID[level],
  }));

  const handleChangeQuestionContent = (value: any) => {
    formRef.setFieldValue(formField.question.name, value);
  };

  const handleChangeOptionContent = (value: any, fieldIndex: number) => {
    const fields = formRef.getFieldsValue();
    const fieldNameOptions = formField.options.name;
    const options = fields[fieldNameOptions]
      ? fields[fieldNameOptions]
      : initialValues[fieldNameOptions];

    options[fieldIndex] = {
      ...options[fieldIndex],
      [formField.option.name]: value,
    };
    formRef.setFieldsValue({ [fieldNameOptions]: options });
  };

  const handleChangeCorrectOption = (event: CheckboxChangeEvent, fieldIndex: number) => {
    const fields = formRef.getFieldsValue();
    const fieldNameOptions = formField.options.name;
    const options = fields[fieldNameOptions];
    options[fieldIndex] = {
      ...options[fieldIndex],
      [formField.value.name]: event.target.checked,
    };
    formRef.setFieldsValue({ [fieldNameOptions]: options });
  };

  return (
    <Form
      layout="horizontal"
      form={formRef}
      onFinish={onSubmit}
      initialValues={initialValues}
      autoComplete="off"
      key={initialValues?.id}
    >
      <Row gutter={[32, 24]}>
        <Col span={16}>
          <Item
            label={formField.question.label}
            name={formField.question.name}
            rules={[{ required: formField.question.required, message: formField.question.errMsg }]}
          >
            <Editor handleEditorChange={handleChangeQuestionContent} />
          </Item>
        </Col>
        <Col span={8}>
          <Row gutter={[24, 8]}>
            <Col span={24}>
              <ProFormSelect
                name={formField.heuristicLevel.name}
                label={formField.heuristicLevel.label}
                options={mapHeuristicLevelOptions}
              />
            </Col>
            <Col span={24}>
              <ProFormSwitch
                name={formField.shuffleAnswers.name}
                label={formField.shuffleAnswers.label}
              />
            </Col>
          </Row>
        </Col>
      </Row>

      <Divider plain={true}>Answer</Divider>

      <Row gutter={[48, 24]}>
        <Col span={24}>
          <List name={formField.options.name}>
            {(fields, { add, remove }) => (
              <>
                <div className="wrapper-answer-content">
                  {fields.map((field, index) => (
                    <Space key={field.key} align="baseline" size="large">
                      <Item
                        noStyle
                        shouldUpdate={(prevValues, curValues) =>
                          prevValues.question !== curValues.question ||
                          prevValues.options !== curValues.options
                        }
                      >
                        {() => (
                          <Item
                            {...field}
                            label={`${formField.option.label} ${index + 1}`}
                            name={[field.name, formField.option.name]}
                            rules={[
                              {
                                required: formField.option.required,
                                message: formField.option.errMsg,
                              },
                            ]}
                          >
                            <Editor
                              handleEditorChange={(value: any) =>
                                handleChangeOptionContent(value, field.name)
                              }
                            />
                          </Item>
                        )}
                      </Item>

                      <Item
                        {...field}
                        name={[field.name, formField.value.name]}
                        initialValue={false}
                        valuePropName="checked"
                      >
                        <Checkbox
                          onChange={(event: CheckboxChangeEvent) =>
                            handleChangeCorrectOption(event, field.name)
                          }
                        >
                          {formField.value.label}
                        </Checkbox>
                      </Item>

                      <Button className="mt-2" type="primary" onClick={() => remove(field.name)}>
                        <MinusCircleFilled /> &nbsp;Close
                      </Button>
                    </Space>
                  ))}
                </div>
                <Item>
                  <Button
                    type="primary"
                    onClick={() => {
                      add();
                    }}
                    icon={<PlusOutlined />}
                  >
                    Add an answer
                  </Button>
                </Item>
              </>
            )}
          </List>
        </Col>
      </Row>

      <Space size={calculateSize(3)} className="w-100 justify-end">
        <Button size="middle" block onClick={onCancel}>
          Cancel
        </Button>
        <Button htmlType="submit" block type="primary" size="middle">
          {initialValues?.answers.length > 0 ? 'Update' : 'Create'}
        </Button>
      </Space>
    </Form>
  );
};

export default TemplateFormFieldMultipleChoiceQuestion;
