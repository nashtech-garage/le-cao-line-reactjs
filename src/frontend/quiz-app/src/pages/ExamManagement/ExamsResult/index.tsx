import { Card, Col, Row, Space, Spin, Typography } from 'antd';
import { SectionTitle } from 'components/Section';
import { MESSAGE_FAILURE } from 'constants/Messages';
import { notificationError } from 'helper/Notification';
import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import examManagementApi from 'redux/api/examManagementApi';
import QuestionContent from '../ExamsExam/components/QuestionContent';

const { Title } = Typography;

function UserResult() {
  const { id } = useParams();
  const [userExamResult, setUserExamResult] = useState<API.ExamResult>();
  const [loading, setLoading] = useState(false);

  const getExamResult = async (id: string | undefined) => {
    if (id) {
      setLoading(true);
      try {
        await examManagementApi.getResultDetail(id).then((res) => {
          if (res.status === 200) {
            const data = res.data.object;
            setUserExamResult(data);
          }
        });
      } catch (err) {
        notificationError(MESSAGE_FAILURE);
      }
    }
    setLoading(false);
  };

  useEffect(() => {
    getExamResult(id);
  }, [id]);

  return (
    <Spin spinning={loading}>
      <Row>
        <Col span={24}>
          <Card className="exam-heading" style={{ backgroundColor: '#003a8c', border: 0 }}>
            <Space align="center" direction="vertical" style={{ display: 'flex' }}>
              <Title level={5} style={{ color: '#ffffff' }}>
                Exam : {userExamResult?.examName}
              </Title>
              <Title level={5} style={{ color: '#ffffff' }}>
                Result : {userExamResult?.resultStatus}
              </Title>
              <Title level={5} style={{ color: '#ffffff' }}>
                Corrects : {userExamResult?.numberOfCorrectAnswer}
              </Title>
              <Title level={5} style={{ color: '#ffffff' }}>
                Submit : {new Date(userExamResult?.createdDate as Date).toLocaleString()}
              </Title>
            </Space>
          </Card>
        </Col>

        {userExamResult?.questions.map((question, index) => {
          return (
            <Col span={16} offset={4}>
              <QuestionContent
                currentQuestion={question as API.Question}
                questionAnswers={userExamResult?.questionAnswers as API.QuestionAnswer[]}
                positionQuestion={index + 1}
              />
            </Col>
          );
        })}
      </Row>
    </Spin>
  );
}

export default UserResult;
