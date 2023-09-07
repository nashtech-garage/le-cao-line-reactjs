import { useSetForm } from '../../../../context/FormContext';
import { ProFormInstance, StepsForm } from '@ant-design/pro-components';
import { ProFormTextArea } from '@ant-design/pro-components';
import {
  ProFormText,
  ProFormSelect,
  ProFormDigit,
  ProFormSwitch,
} from '@ant-design/pro-components';
import { Form, Row, Col, Button } from 'antd';
import { Content } from 'antd/lib/layout/layout';
import React, { useEffect, useRef, useState } from 'react';
import QuestionTable from '../QuestionTable';
import SelectedQuestionsTable from '../SelectedQuestionsTable';
import TemplateFormFieldSchedule from '../TemplateFormFieldSchedule';

interface Props {
  formField: any;
  formRef: React.MutableRefObject<ProFormInstance<any> | undefined>;
  onSubmit?: any;
  initialValues?: any;
}

const TemplateFormFieldExam: React.FC<Props> = ({
  formField,
  formRef,
  onSubmit,
  initialValues,
}) => {
  const formQuestionsRef = useRef<ProFormInstance>();
  useSetForm(formQuestionsRef);
  const [selectedQuestions, setSelectedQuestions] = useState<API.Question[]>([]);

  const handleChangeFieldValue = (value: any, fieldIndex: string) => {
    formRef.current?.setFieldsValue({ [fieldIndex]: value });
  };

  const handleChangeSelectedQuestions = (value: API.Question) => {
    setSelectedQuestions([...selectedQuestions.concat(value)]); // TODO can bug
  };

  useEffect(() => {
    setSelectedQuestions(initialValues.questions);
    formQuestionsRef.current?.setFieldsValue({
      questions: initialValues.questions,
    });
  }, [initialValues]);

  useEffect(() => {
    handleChangeFieldValue(selectedQuestions, formField.questionList.name);
  }, [selectedQuestions]);

  return (
    initialValues && (
      <StepsForm
        onFinish={onSubmit}
        formProps={{
          validateMessages: {
            required: 'This field is required',
          },
        }}
        formRef={formRef}
        submitter={{
          render: (props) => {
            if (props.step === 0) {
              return (
                <Button type="primary" onClick={() => props.onSubmit?.()}>
                  Next
                </Button>
              );
            }

            if (props.step === 1 || props.step === 2) {
              return [
                <Button key="pre" onClick={() => props.onPre?.()}>
                  Previous
                </Button>,
                <Button type="primary" key="goToTree" onClick={() => props.onSubmit?.()}>
                  Next
                </Button>,
              ];
            }

            return [
              <Button key="gotoTwo" onClick={() => props.onPre?.()}>
                Previous
              </Button>,
              <Button type="primary" key="goToTree" onClick={() => props.onSubmit?.()}>
                Finish
              </Button>,
            ];
          },
        }}
      >
        <StepsForm.StepForm
          name="examDetails"
          title="Details"
          layout="vertical"
          initialValues={initialValues}
          autoComplete="off"
        >
          <Content
            style={{ marginBottom: '24px', width: '1024px', height: '600px', overflow: 'auto' }}
          >
            <ProFormText
              name={formField.name.name}
              label={formField.name.label}
              placeholder={formField.name.placeholder}
              rules={[
                {
                  required: formField.name.required,
                },
              ]}
            />
            <ProFormTextArea
              name={formField.description.name}
              label={formField.description.label}
              placeholder={formField.description.placeholder}
              rules={[
                {
                  required: formField.description.required,
                },
              ]}
            />
            {/* <ProFormSelect
              name={formField.tags.name}
              label={formField.tags.label}
              placeholder={formField.tags.placeholder}
              fieldProps={{ mode: 'tags' }}
              options={['MATH', 'MUSIC'].map((item) => ({
                label: item,
                value: item,
              }))}
            /> */}
          </Content>
        </StepsForm.StepForm>
        <StepsForm.StepForm name="examQuestions" title="Questions" formRef={formQuestionsRef}>
          <Content
            style={{ marginBottom: '24px', width: '1424px', height: '600px', overflow: 'auto' }}
          >
            <Form.Item
              name={formField.questionList.name}
              label={formField.questionList.label}
              rules={[
                {
                  required: formField.questionList.required,
                  message: formField.questionList.errMsg,
                },
              ]}
            >
              <Row>
                <Col span={14}>
                  <QuestionTable
                    handleSelectQuestion={(value: any) => handleChangeSelectedQuestions(value)}
                  />
                </Col>
                <Col span={8} offset={2}>
                  <SelectedQuestionsTable
                    selectedQuestions={selectedQuestions}
                    setSelectedQuestions={setSelectedQuestions}
                  />
                </Col>
              </Row>
            </Form.Item>
          </Content>
        </StepsForm.StepForm>
        <StepsForm.StepForm name="examSchedules" title="Schedules" initialValues={initialValues}>
          <Content
            style={{ marginBottom: '24px', width: '1024px', height: '600px', overflow: 'auto' }}
          >
            <Form.Item
              name={formField.scheduleList.name}
              label={formField.scheduleList.label}
              rules={[
                {
                  required: formField.scheduleList.required,
                  message: formField.scheduleList.errMsg,
                },
              ]}
            >
              <TemplateFormFieldSchedule
                initialValues={initialValues}
                handleChangeFieldValue={handleChangeFieldValue}
                scheduleListFieldName={formField.scheduleList.name}
              />
            </Form.Item>
          </Content>
        </StepsForm.StepForm>
        <StepsForm.StepForm
          name="examSettings"
          title="Settings"
          initialValues={initialValues}
          onFinish={async () => {
            return true;
          }}
          layout="horizontal"
          className="exam-setting"
        >
          <Content
            style={{ marginBottom: '24px', width: '1024px', height: '600px', overflow: 'auto' }}
          >
            <Row>
              <Col span={10}>
                <ProFormDigit
                  name={formField.plusScorePerQuestion.name}
                  label={formField.plusScorePerQuestion.label}
                  min="0"
                  max="100"
                />
                <ProFormDigit
                  name={formField.minusScorePerQuestion.name}
                  label={formField.minusScorePerQuestion.label}
                  min="0"
                  max="100"
                />
                <ProFormDigit
                  name={formField.timePerQuestion.name}
                  label={formField.timePerQuestion.label}
                  min="0"
                  max="100"
                />
                <ProFormDigit
                  name={formField.shufflingExams.name}
                  label={formField.shufflingExams.label}
                  min="0"
                  max="100"
                />
                <ProFormDigit
                  name={formField.percentageToPass.name}
                  label={formField.percentageToPass.label}
                  min="0"
                  max="100"
                />
              </Col>
              <Col span={10} offset={4}>
                <ProFormSwitch
                  name={formField.viewPassQuestion.name}
                  label={formField.viewPassQuestion.label}
                />
                <ProFormSwitch
                  name={formField.viewNextQuestion.name}
                  label={formField.viewNextQuestion.label}
                />
                <ProFormSwitch
                  name={formField.showAllQuestion.name}
                  label={formField.showAllQuestion.label}
                />
                <ProFormSwitch
                  name={formField.hideResult.name}
                  label={formField.hideResult.label}
                />
              </Col>
            </Row>
          </Content>
        </StepsForm.StepForm>
      </StepsForm>
    )
  );
};

export default TemplateFormFieldExam;
