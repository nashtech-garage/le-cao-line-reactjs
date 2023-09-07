import { MinusCircleOutlined } from '@ant-design/icons';
import { ProCard } from '@ant-design/pro-components';
import { Card, Col, Row } from 'antd';
import Editor from 'components/Editor';
import React from 'react';

interface IQuestionListProps {
  selectedQuestions: API.Question[];
  setSelectedQuestions: React.Dispatch<React.SetStateAction<API.Question[]>>;
}

const SelectedQuestionsTable: React.FC<IQuestionListProps> = ({
  selectedQuestions,
  setSelectedQuestions,
}) => {
  const handleUnselectQuestion = (id: string) => {
    setSelectedQuestions((current) =>
      current.filter((item) => {
        return item.id !== id;
      })
    );
  };

  return (
    <ProCard title="There are your selected question">
      {selectedQuestions.map((item) => {
        return (
          <Card key={item.id}>
            <Row>
              <Col span={22}>
                <Editor
                  modules={{ toolbar: false }}
                  theme="snow"
                  value={item.questionContent}
                  isReadOnly={true}
                  handleEditorChange={() => null}
                />
              </Col>
              <Col span={2}>
                <Row justify="end">
                  <MinusCircleOutlined
                    className="dynamic-delete-button"
                    onClick={() => handleUnselectQuestion(item.id)}
                  />
                </Row>
              </Col>
            </Row>
          </Card>
        );
      })}
    </ProCard>
  );
};

export default SelectedQuestionsTable;
