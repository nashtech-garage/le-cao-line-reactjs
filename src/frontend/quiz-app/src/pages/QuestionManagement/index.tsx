import { CloudUploadOutlined, DeleteOutlined, EditTwoTone, PlusOutlined } from '@ant-design/icons';
import { Button, Popconfirm, Row, Space, Spin, Table, Tag } from 'antd';
import { ColumnsType } from 'antd/lib/table';
import { useAppSelector } from 'app/hooks';
import Editor from 'components/Editor';
import { GEEKBLUE, GREEN, VOLCANO } from 'constants/color';
import {
  ACTION_COLUMN,
  LEVEL_COLUMN,
  NUMBER_OF_COLUMN,
  QUESTION_CONTENT_COLUMN,
  QUESTION_TYPE_COLUMN,
  TAG_QUESTION_COLUMN
} from 'constants/column';
import { LOSER } from 'constants/constants';
import { DELETE_QUESTION__SUCCESS, MESSAGE_FAILURE } from 'constants/Messages';
import { ITEM_PER_PAGE } from 'constants/numberValue';
import { notificationError, notificationSuccess } from 'helper/Notification';
import { useCallback, useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import QuestionApi from 'redux/api/QuestionApi';
import ModalSelectQuestionType from './components/ModalSelectQuestionType';
import ModalUploadQuestion from './components/ModalUploadQuestion';

function QuestionManagement() {
  const [isOpenModal, setOpenModal] = useState<boolean>(false);
  const [pageShow, setPageShow] = useState({
    pageSize: ITEM_PER_PAGE,
    current: 1,
  });
  const [isModalUploadOpen, setIsModalUploadOpen] = useState(false);
  const [total, setTotal] = useState(5);
  const [questions, setQuestions] = useState<API.Question[]>([]);
  const [loading, setLoading] = useState<boolean>(false);

  const user = useAppSelector((state) => state.auth.user);

  const getData = useCallback(
    async (page?: number) => {
      try {
        setLoading(true);
        const res = await QuestionApi.getQuestions(
          page || pageShow.current,
          user.roles.find((x: string) => x === 'admin') ? '' : user.email
        );
        if (res.status === 200) {
          setQuestions(res.data.object.object);
          setTotal(res.data.object.total);
        }
      } catch (error) {
        return null;
      }
      setLoading(false);
    },
    [pageShow]
  );

  useEffect(() => {
    getData();
  }, [getData]);

  const modules = {
    toolbar: false,
  };
  const questionTableColumns: ColumnsType<API.Question> = [
    {
      title: NUMBER_OF_COLUMN,
      dataIndex: 'index',
      key: 'index',
      render: (value, item, index) =>
        pageShow.current === 1 ? index + 1 : (pageShow.current - 1) * ITEM_PER_PAGE + (index + 1),
      width: 48,
    },
    {
      title: QUESTION_TYPE_COLUMN,
      dataIndex: 'questionType',
      key: 'questionType',
    },
    {
      title: LEVEL_COLUMN,
      dataIndex: 'level',
      key: 'level',
    },
    {
      title: TAG_QUESTION_COLUMN,
      dataIndex: 'tagQuestions',
      key: 'tagQuestions',
      render: (_: any, record: any) => (
        <>
          {record.tagQuestions.map((tag: any) => {
            let color = tag.length > 5 ? GEEKBLUE : GREEN;

            if (tag === LOSER) {
              color = VOLCANO;
            }

            return (
              <Tag color={color} key={`${tag}_${record.id}`}>
                {tag.toUpperCase()}
              </Tag>
            );
          })}
        </>
      ),
    },
    {
      title: QUESTION_CONTENT_COLUMN,
      dataIndex: 'questionContent',
      key: 'questionContent',
      width: 500,
      render: (text) => <Editor handleEditorChange={() => null} isReadOnly modules={modules} theme="snow" value={text} />,
    },
    {
      title: ACTION_COLUMN,
      key: 'action',
      render: (_: any, record: any) => [
        <div key={record?.id}>
          <Popconfirm
            key={`popup_${record.id}`}
            title="Delete"
            onConfirm={() => {
              handleRemoveQuestion(record.id);
            }}
            okText="Yes"
            cancelText="No"
          >
            <Button
              key={`delete_${record.id}`}
              type="link"
              danger
              icon={<DeleteOutlined key={`icon_delete_${record.id}`} />}
            />
          </Popconfirm>
          <Link to={`/question-management/edit-question/${record.id}`} key={record.id}>
            <Button type="link" icon={<EditTwoTone />} />
          </Link>
        </div>,
      ],
    },
  ];

  const showModalUpload = () => {
    setIsModalUploadOpen(true);
  };

  const paginationChange = (page: number, pageSize?: number) => {
    setPageShow({ ...pageShow, current: page });
    getData(page);
  };

  const handleRemoveQuestion = async (questionId: string) => {
    try {
      await QuestionApi.removeQuestion(questionId);
      await setLoading(true);
      await notificationSuccess(DELETE_QUESTION__SUCCESS);
      await getData();
    } catch (error) {
      notificationError(MESSAGE_FAILURE);
    }
    setLoading(false);
  };

  return (
    <Spin spinning={loading}>
      <ModalSelectQuestionType isOpenModal={isOpenModal} setOpenModal={setOpenModal} />
      <Row justify="end" className="mb-xs">
        <Space>
          <Button
            type="primary"
            icon={<PlusOutlined />}
            key="createQuestion"
            onClick={() => setOpenModal(true)}
          >
            <span>Create</span>
          </Button>
          <Button onClick={showModalUpload} icon={<CloudUploadOutlined />}>
            <span>Upload Question</span>
          </Button>
          <ModalUploadQuestion
            isOpenModal={isModalUploadOpen}
            setOpenModal={setIsModalUploadOpen}
          />
        </Space>
      </Row>
      <Table<API.Question>
        columns={questionTableColumns}
        dataSource={questions}
        style={{ textAlign: 'center' }}
        pagination={{
          pageSize: pageShow.pageSize,
          total: total,
          defaultCurrent: pageShow.current,
          showSizeChanger: false,
          onChange: paginationChange,
          showTotal: (total, range) => `${range[0]}-${range[1]} of ${total} items`,
        }}
      />
    </Spin>
  );
}

export default QuestionManagement;
