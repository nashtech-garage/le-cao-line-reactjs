import { RightOutlined } from '@ant-design/icons';
import { Modal } from 'antd';
import { MAP_QUESTION_TYPE_SHORT, QUESTION_TYPE_STRING } from 'constants/exam';
import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

interface IProps {
  isOpenModal: boolean;
  setOpenModal: any;
}

const ModalSelectQuestionType: React.FC<IProps> = ({ isOpenModal, setOpenModal }) => {
  const [questionTypeList, setQuestionTypeList] = useState<API.QuestionType[]>([]);

  useEffect(() => {
    //call API get question type list
    const item: API.QuestionType[] = [
      {
        id: MAP_QUESTION_TYPE_SHORT[QUESTION_TYPE_STRING.MULTIPLE_CHOICE_QUESTION],
        name: QUESTION_TYPE_STRING.MULTIPLE_CHOICE_QUESTION,
        description: '',
      },
    ];
    setQuestionTypeList(item);
  }, []);

  return (
    <Modal
      title="Choose a question type"
      visible={isOpenModal}
      onCancel={() => setOpenModal(false)}
      width={500}
      footer={null}
    >
      <div className="modal">
        {questionTypeList.map((questionType: API.QuestionType) => {
          return (
            <Link to={`/question-management/add-question`} key={questionType.id}>
              <div className="content">
                <div className="modal-content">
                  <span>{questionType.name}</span>
                  <span>{questionType.description}</span>
                </div>
                <div className="modal-image">
                  <RightOutlined />
                </div>
              </div>
            </Link>
          );
        })}
      </div>
    </Modal>
  );
};

export default ModalSelectQuestionType;
