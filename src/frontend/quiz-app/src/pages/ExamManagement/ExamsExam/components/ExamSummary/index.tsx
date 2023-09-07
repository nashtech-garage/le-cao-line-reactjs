import { Typography, Card, Row, Col, Button } from 'antd';
import {
  COLOR_ANSWER_IS_CHOICE,
  COLOR_ANSWER_IS_NOT_CHOICE,
  COLOR_TEXT,
  WHITE,
} from 'constants/color';
import React from 'react';

const QuestionStateStyle: React.CSSProperties = {
  width: '24px',
  height: '24px',
  marginRight: '8px',
  display: 'inline-block',
  borderColor: '#343a40',
  border: '1px solid #dee2e6',
};

const { Text, Title } = Typography;

interface Props {
  questionList: API.Question[];
  setCurrentIndex: any;
  questionAnswers: API.QuestionAnswer[];
  onSubmitExam: any;
}

const ExamSummary: React.FC<Props> = ({
  questionList,
  setCurrentIndex,
  questionAnswers,
  onSubmitExam,
}) => {
  return (
    <Card>
      <Row className="question-state" gutter={[32, 16]}>
        <Col className="gutter-row" span={12}>
          <div className="flex-center-center">
            <div
              style={{
                ...QuestionStateStyle,
                background: '#063970',
                textAlign: 'center',
              }}
            />
            <Text strong>Answered</Text>
          </div>
        </Col>
        <Col className="gutter-row" span={12}>
          <div className="flex-center-center">
            <div
              style={{
                ...QuestionStateStyle,
                background: '#eeeee4',
              }}
            />
            <Text strong>Not answered</Text>
          </div>
        </Col>
        <Col span={24}>
          <Text type="secondary">Click on button to view question</Text>
        </Col>
        <Col className="gutter-row" span={24}>
          <Row gutter={[16, 16]}>
            {questionList?.map((x, index) => {
              const did = questionAnswers.filter((qa) => qa.questionId === x.id)[0];
              return (
                <Col key={x.id} span={3}>
                  <Button
                    shape="round"
                    size="large"
                    className="answer_exam_item"
                    onClick={() => setCurrentIndex(index)}
                    style={{
                      backgroundColor:
                        did?.answerId !== '' ? COLOR_ANSWER_IS_CHOICE : COLOR_ANSWER_IS_NOT_CHOICE,
                    }}
                  >
                    <Text
                      strong
                      style={{
                        color: did?.answerId !== '' ? WHITE : COLOR_TEXT,
                      }}
                    >
                      {index + 1}
                    </Text>
                  </Button>
                </Col>
              );
            })}
          </Row>
        </Col>
        <Button
          type="primary"
          block
          style={{ height: '50px', backgroundColor: '#003a8c' }}
          onClick={onSubmitExam}
        >
          <Title level={2} style={{ color: WHITE }}>
            FINISH
          </Title>
        </Button>
      </Row>
    </Card>
  );
};

export default ExamSummary;
