import {
  ArrowLeftOutlined,
  ArrowRightOutlined,
  CheckOutlined,
  ClockCircleOutlined,
} from '@ant-design/icons';
import { ProCard } from '@ant-design/pro-components';
import { Button, Card, Col, RadioChangeEvent, Row, Space, Spin } from 'antd';
import Countdown from 'antd/lib/statistic/Countdown';
import { useAppSelector } from 'app/hooks';
import {
  FAILED,
  MESSAGE_EXAM_FAILED,
  MESSAGE_EXAM_SUCCESS,
  MESSAGE_FAILURE,
  TRY_AGAIN_MESSAGE,
} from 'constants/Messages';
import { notificationError } from 'helper/Notification';
import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import examManagementApi from 'redux/api/examManagementApi';
import Swal from 'sweetalert2';
import ExamHeading from './components/ExamHeading';
import ExamSummary from './components/ExamSummary';
import QuestionContent from './components/QuestionContent';

function DoExam() {
  const { id } = useParams();
  const user = useAppSelector((state) => state.auth.user);
  const [userExam, setUserExam] = useState<API.Exam>();
  const [isSubmitted, setIsSubmitted] = useState<boolean>(false);
  const [schedule, setSchedule] = useState<API.Schedule>();
  const [questionList, setQuestionList] = useState<API.Question[]>([]);
  const [questionAnswers, setQuestionAnswers] = useState<API.QuestionAnswer[]>([]);
  const [currentQuestion, setCurrentQuestion] = useState<API.Question>();
  const [currentQuestionId, setCurrentQuestionId] = useState<string>('');
  const [currentIndex, setCurrentIndex] = useState(0);
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();
  const path = useParams();

  const getExam = async (id: string | undefined) => {
    if (id) {
      try {
        const res = await examManagementApi.takeExam(id);
        if (res.status === 200) {
          setUserExam(res.data.object);
        }
      } catch (err) {
        notificationError(MESSAGE_FAILURE);
      }
    }
  };

  useEffect(() => {
    getExam(id);
  }, []);

  useEffect(() => {
    if (userExam) {
      const questionMap: API.Question[] = userExam.questions.map((x) => {
        return x as API.Question;
      });
      setQuestionList(questionMap);
      setSchedule(userExam.schedules[0]);
    }
  }, [userExam]);

  useEffect(() => {
    if (questionList) {
      setQuestionAnswers(
        questionList.map((x) => {
          return {
            questionId: x.id,
            answerId: '',
          };
        })
      );
      setCurrentIndex(0);
      setCurrentQuestion(questionList[0]);
      setCurrentQuestionId(questionList[0]?.id);
    }
  }, [questionList]);

  useEffect(() => {
    if (questionList) {
      setCurrentQuestion(questionList[currentIndex]);
      setCurrentQuestionId(questionList[currentIndex]?.id);
    }
  }, [currentIndex, questionList]);

  const onSelectOption = (e: RadioChangeEvent) => {
    let result: API.QuestionAnswer[] = [];
    if (questionAnswers.find((x) => x.questionId === currentQuestionId)) {
      result = questionAnswers.map((x) =>
        x.questionId === questionList[currentIndex].id ? { ...x, answerId: e.target.value } : x
      );
    } else {
      const questionAnswer: API.QuestionAnswer = {
        questionId: currentQuestionId,
        answerId: e.target.value,
      };
      result = [...questionAnswers, questionAnswer];
    }
    setQuestionAnswers(result);
  };

  useEffect(() => {
    setLoading(true);
    setTimeout(() => {
      setLoading(false);
    }, 500);
  }, []);

  const onSubmitExam = async () => {
    await examManagementApi
      .submitExam({
        questionAnswers: questionAnswers,
        examId: id,
        userId: user ? user.email : '',
      })
      .then((result: any) => {
        const examResult = result.data.object;
        result.data.object?.resultStatus === FAILED ? (
          Swal.fire({
            icon: 'error',
            title: MESSAGE_EXAM_FAILED,
            text: `You have ${(
              (examResult?.numberOfCorrectAnswer / examResult?.questionAnswers.length) *
              100
            ).toFixed(2)}/100 point`,
            footer: `<a href=/exams/${path.id}/exam>${TRY_AGAIN_MESSAGE}</a>`,
            background:
              '#fff url(https://media.tenor.com/aIGG2GPWrE0AAAAM/cry-crying.gif) no-repeat',
            backdrop: `
                rgba(0,0,0,0.4)
                left top
                no-repeat
              `,
            didClose: () => {
              navigate('/home');
            },
          })
        ) : (
          <>
            {Swal.fire({
              title: `${MESSAGE_EXAM_SUCCESS}  you have ${(
                (examResult?.numberOfCorrectAnswer / examResult?.questionAnswers.length) *
                100
              ).toFixed(2)}/100 point`,
              width: 600,
              padding: '3em',
              timer: 4000,
              timerProgressBar: true,
              color: '#716add',
              didClose: () => {
                navigate('/home');
              },
              background:
                '#fff url(https://i.pinimg.com/originals/a5/da/be/a5dabea9202dcfef09cb11340fd86192.gif)',
              backdrop: `
                  rgba(0,0,123,0.4)
                  url("https://sweetalert2.github.io/images/nyan-cat.gif")
                  left top
                  no-repeat
                `,
            })}
          </>
        );
        setIsSubmitted(true);
      });
  };

  const examMainContentActions = [
    // <Button key="viewResult" icon={<CheckOutlined />} size="large" onClick={() => {}}>
    //   View result
    // </Button>,
    <Button
      key="previousQuestion"
      icon={<ArrowLeftOutlined />}
      size="large"
      disabled={!userExam?.viewPassQuestion || currentIndex === 0}
      onClick={() => setCurrentIndex(currentIndex - 1)}
    >
      Previous
    </Button>,
    <Button
      key="nextQuestion"
      icon={<ArrowRightOutlined />}
      size="large"
      disabled={!userExam?.viewNextQuestion || currentIndex + 1 === questionList?.length}
      onClick={() => setCurrentIndex(currentIndex + 1)}
    >
      Next
    </Button>,
  ];

  return userExam ? (
    <Spin spinning={loading}>
      <Row gutter={[0, 24]}>
        <Col span={24}>
          <ExamHeading templateExam={userExam} time={schedule?.time} />
        </Col>
        <Col span={24}>
          {isSubmitted ? (
            <></>
          ) : (
            <Row gutter={[48, 0]} className="exam-content w-100">
              <Col offset={2} span={12} className="exam-main-content">
                <ProCard actions={examMainContentActions}>
                  <QuestionContent
                    currentQuestion={currentQuestion}
                    onSelectOption={onSelectOption}
                    questionAnswers={questionAnswers}
                    positionQuestion={currentIndex + 1}
                  />
                </ProCard>
              </Col>
              <Col span={8} className="do-exam-wrapper">
                <Card>
                  <Space direction="horizontal" style={{ width: '100%', justifyContent: 'center' }}>
                    <Space align="center">
                      <ClockCircleOutlined style={{ fontSize: '32px', color: '#003a8c' }} />
                      <Countdown
                        value={Date.now() + 1000 * 60 * 15}
                        onFinish={onSubmitExam}
                        valueStyle={{ color: '#003a8c' }}
                      />
                    </Space>
                  </Space>
                </Card>

                <ExamSummary
                  questionList={questionList}
                  setCurrentIndex={setCurrentIndex}
                  questionAnswers={questionAnswers}
                  onSubmitExam={onSubmitExam}
                />
              </Col>
            </Row>
          )}
        </Col>
      </Row>
    </Spin>
  ) : (
    <></>
  );
}

export default DoExam;
