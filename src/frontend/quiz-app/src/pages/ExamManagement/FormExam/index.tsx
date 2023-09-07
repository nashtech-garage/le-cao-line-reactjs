import { useState } from 'react';
import { useRef } from 'react';
import { useSetForm } from '../../../context/FormContext';
import formSchema from '../../../schemas/exams/examSchema';
import { useNavigate } from 'react-router-dom';
import { getInitialValue } from '../../../schemas/exams/getInitialValues';

import type { ProFormInstance } from '@ant-design/pro-components';
import TemplateFormFieldExam from '../components/TemplateFormFieldExam';
import { Spin } from 'antd';
import examManagementApi from 'redux/api/examManagementApi';
import { MESSAGE_FAILURE } from 'constants/Messages';
import { notificationError } from 'helper/Notification';
import { useAppSelector } from 'app/hooks';

interface IExamForm {
  exam?: API.Exam;
}

const ExamForm: React.FC<IExamForm> = ({ exam }) => {
  const [loading, setLoading] = useState<boolean>(false);
  const history = useNavigate();
  const form = useRef<ProFormInstance>();
  useSetForm(form);
  const { formField } = formSchema;

  const user = useAppSelector((state) => state.auth.user);

  const handleConfirmCancel = () => {
    history('/exams');
  };

  function handleViewExam(id: string) {
    history('/exams');
  }

  const cb = (id: string) => {
    setLoading(false);
    form.current?.resetFields();
    return exam ? handleConfirmCancel() : handleViewExam(id);
  };

  const saveExam = async (examInfo: API.Exam) => {
    let res;
    res = exam
      ? await examManagementApi.update({ ExamId: exam.id, Exam: examInfo })
      : await examManagementApi.create({ Exam: examInfo, UserId: user.email });
    if (res.status === 201) {
      if (exam && exam.id) cb(exam.id.toString());
      else cb(res.data.examId);
      return res;
    } else {
      notificationError(MESSAGE_FAILURE);
      setLoading(false);
    }
  };

  const handleSubmit = async (value: any) => {
    setLoading(true);
    const examInfo: API.Exam = {
      ...value,
      code: `EXAM${new Date().toISOString().slice(0, 19).replace(/-/g, '').replace(/:/g, '')}`,
      defaultQuestionNumber: value.questions.length,
      type: 'exam',
      questionBankType: 'system',
      questions: value.questions.map((x: API.Question) => x.id),
    };
    await saveExam(examInfo);
  };

  return (
    <Spin spinning={loading}>
      <TemplateFormFieldExam
        formField={formField}
        formRef={form}
        initialValues={getInitialValue(exam)}
        onSubmit={handleSubmit}
      />
    </Spin>
  );
};

export default ExamForm;
