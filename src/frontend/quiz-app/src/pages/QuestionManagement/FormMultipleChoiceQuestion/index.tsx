import { Form, Spin } from 'antd';
import { useAppDispatch, useAppSelector } from 'app/hooks';
import { MAP_QUESTION_TYPE_ID, QUESTION_TYPE } from 'constants/exam';
import {
  INSERT_QUESTION_SUCCESS,
  MESSAGE_FAILURE,
  UPDATE_QUESTION__SUCCESS,
} from 'constants/Messages';
import { useSetForm } from 'context/FormContext';
import { notificationError, notificationSuccess } from 'helper/Notification';
import { FC, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import QuestionApi from 'redux/api/QuestionApi';
import { getInitialValue } from '../../../schemas/questions/getInitialValues';
import formSchema from '../../../schemas/questions/questionSchema';
import TemplateFormFieldMultipleChoiceQuestion from '../components/TemplateFormFieldMultipleChoiceQuestion';

interface IMultipleChoiceQuestionForm {
  question?: API.Question;
}

const MultipleChoiceQuestionForm: FC<IMultipleChoiceQuestionForm> = ({ question }) => {
  const { formField } = formSchema;
  const [loading, setLoading] = useState<boolean>(false);
  const dispatch = useAppDispatch();
  const history = useNavigate();
  const [form] = Form.useForm();

  const user = useAppSelector((state) => state.auth.user);

  useSetForm(form);

  const handleConfirmCancel = () => {
    history('/question-management');
  };

  const createQuestionApi = async (questionInfo: API.Question) => {
    try {
      await setLoading(true);
      await QuestionApi.createQuestion({ ...questionInfo, userId: user.email });
      await notificationSuccess(INSERT_QUESTION_SUCCESS);
      await history('/question-management');
      form.resetFields();
    } catch (error) {
      notificationError(MESSAGE_FAILURE);
    }
    setLoading(false);
  };

  const updateQuestionApi = async (questionInfo: API.Question) => {
    try {
      await setLoading(true);
      await QuestionApi.updateQuestion(questionInfo);
      await notificationSuccess(UPDATE_QUESTION__SUCCESS);
      await history('/question-management');
      form.resetFields();
    } catch (error) {
      notificationError(MESSAGE_FAILURE);
    }
    setLoading(false);
  };

  const saveQuestion = async (questionInfo: API.Question) => {
    question ? updateQuestionApi(questionInfo) : createQuestionApi(questionInfo);
  };

  const handleSubmit = async (value: any) => {
    const answers = value.answers.map((answer: any) => {
      return { ...answer, answerValue: answer.answerValue.toString() };
    });

    const questionInfo: API.Question = {
      ...question,
      ...value,
      answers: answers,
      questionTypeId: MAP_QUESTION_TYPE_ID[QUESTION_TYPE.MULTIPLE_CHOICE_QUESTION],
    };

    await saveQuestion(questionInfo);
  };

  return (
    <Spin spinning={loading}>
      <TemplateFormFieldMultipleChoiceQuestion
        formField={formField}
        formRef={form}
        initialValues={getInitialValue(question)}
        onSubmit={handleSubmit}
        onCancel={handleConfirmCancel}
      />
    </Spin>
  );
};

export default MultipleChoiceQuestionForm;
