import { MESSAGE_FAILURE } from 'constants/Messages';
import { notificationError } from 'helper/Notification';
import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import examManagementApi from 'redux/api/examManagementApi';
import ExamForm from '../FormExam';

function ExamUpdationPage() {
  const { id } = useParams();
  const [exam, setExam] = useState<API.Exam>();

  const getExam = async (id: string | undefined) => {
    if (id) {
      try {
        const res = await examManagementApi.getDetail(id);
        if (res.status === 200) {
          setExam(res.data.object);
        }
      } catch (err) {
        notificationError(MESSAGE_FAILURE);
      }
    }
  };

  useEffect(() => {
    getExam(id);
  }, []);

  return exam ? <ExamForm exam={exam} /> : <></>;
}

export default ExamUpdationPage;
