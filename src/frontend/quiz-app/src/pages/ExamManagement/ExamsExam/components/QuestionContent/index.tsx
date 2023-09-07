import { ProCard } from '@ant-design/pro-components';
import { Divider, Radio, Row, Space, Typography } from 'antd';
import Editor from 'components/Editor';
import React, { useEffect, useState } from 'react';

const { Text } = Typography;

interface Props {
  currentQuestion: API.Question | undefined;
  onSelectOption?: any;
  questionAnswers: API.QuestionAnswer[];
  positionQuestion?: number;
}

const QuestionContent: React.FC<Props> = ({
  currentQuestion,
  onSelectOption,
  questionAnswers,
  positionQuestion,
}) => {
  const [selectedValue, setSelectedValue] = useState<string | undefined>();

  useEffect(() => {
    const questionAnswer = questionAnswers.filter((x) => x.questionId === currentQuestion?.id)[0];
    if (questionAnswer) {
      setSelectedValue(questionAnswer.answerId);
    } else {
      setSelectedValue(undefined);
    }
  }, [currentQuestion, questionAnswers]);
  const modules = {
    toolbar: false,
  };
  return (
    <ProCard
      title={`Question ${positionQuestion}`}
      style={{ height: '400px', overflow: 'auto' }}
      className="exam__question__content"
    >
      {currentQuestion && (
        <Row gutter={[0, 8]}>
          <Editor
            handleEditorChange={() => null}
            modules={modules}
            theme="snow"
            value={currentQuestion.questionContent}
            isReadOnly={true}
          />
          <Divider>
            <Text type="secondary">Answers</Text>
          </Divider>
          <Radio.Group key={currentQuestion.id} onChange={onSelectOption} value={selectedValue}>
            <Space direction="vertical">
              {currentQuestion.answers?.map((x) => (
                <Radio key={`${currentQuestion.id}_${x.id}`} value={x.id}>
                  <Editor
                    isBorderClass={true}
                    isReadOnly={true}
                    handleEditorChange={() => null}
                    modules={modules}
                    value={x.answerContent}
                  />
                </Radio>
              ))}
            </Space>
          </Radio.Group>
        </Row>
      )}
    </ProCard>
  );
};

export default QuestionContent;
