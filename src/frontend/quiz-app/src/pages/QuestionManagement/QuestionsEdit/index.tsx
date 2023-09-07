import { Breadcrumb, Spin } from 'antd';
import { useAppDispatch} from 'app/hooks';
import { QUESTION_TYPE } from 'constants/exam';
import { MESSAGE_FAILURE } from 'constants/Messages';
import { notificationError } from 'helper/Notification';
import { useEffect, useState } from 'react';
import { Link, Route, Routes, useLocation, useParams } from 'react-router-dom';
import { detailQuestion } from 'redux/features/questionSlice';
import QuestionManagement from '..';
import MultipleChoiceQuestionForm from '../FormMultipleChoiceQuestion';

function QuestionUpdationPage() {
  const { id } = useParams();
  const location = useLocation();
  const [question, setQuestion] = useState<API.Question>();
  const dispatch = useAppDispatch();
  const [loading, setLoading] = useState(false);
  const getQuestion = async (id: string | undefined) => {
    setLoading(true);
    if (id) {
      try {
        await dispatch(detailQuestion(id)).then((result) => {
          setQuestion(result.payload);
        });
      } catch (err) {
        notificationError(MESSAGE_FAILURE);
      }
    }
    setTimeout(() => {
      setLoading(false);
    }, 1000);
  };

  useEffect(() => {
    getQuestion(id);
  }, []);

  const Components = {
    [QUESTION_TYPE.MULTIPLE_CHOICE_QUESTION]: MultipleChoiceQuestionForm,
  };

  const FormComponent = Components[QUESTION_TYPE.MULTIPLE_CHOICE_QUESTION];
  const breadcrumbNameMap: any = {
    '/question-management': 'Question Management',
    '/question-management/add-question': 'Add Question',
    '/question-management/edit-question': 'Edit Question',
  };

  const pathSnippets = location.pathname.split('/').filter((i) => i);
  const extraBreadcrumbItems = pathSnippets.map((_, index) => {
    const url: any = `/${pathSnippets.slice(0, index + 1).join('/')}`;
    return (
      <Breadcrumb.Item key={url}>
        {breadcrumbNameMap[url] && <Link to={url}> {breadcrumbNameMap[url]}</Link>}
      </Breadcrumb.Item>
    );
  });
  const breadcrumbItems = [<Breadcrumb.Item key="question-management"></Breadcrumb.Item>].concat(
    extraBreadcrumbItems
  );
  return question ? (
    <Spin spinning={loading}>
      <div className="demo" style={{ marginBottom: 30 }}>
        <Routes>
          <Route path="/question-management" element={<QuestionManagement />} />
        </Routes>
        <Breadcrumb>{breadcrumbItems}</Breadcrumb>
      </div>
      <FormComponent question={question} />
    </Spin>
  ) : (
    <></>
  );
}

export default QuestionUpdationPage;
