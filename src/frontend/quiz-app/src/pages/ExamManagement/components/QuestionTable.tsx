import { Button, Card, Row, Space, Table } from 'antd';
import { ColumnsType } from 'antd/lib/table';
import { useAppDispatch, useAppSelector } from 'app/hooks';
import Editor from 'components/Editor';
import { MESSAGE_FAILURE } from 'constants/Messages';
import { ITEM_PER_PAGE } from 'constants/numberValue';
import { notificationError } from 'helper/Notification';
import type { Key } from 'react';
import React, { useEffect, useState } from 'react';
import { retrieveQuestions } from 'redux/features/questionSlice';

interface IQuestionListProps {
  handleSelectQuestion: any;
}

const QuestionTable: React.FC<IQuestionListProps> = ({ handleSelectQuestion }) => {
  const [questionList, setQuestionList] = useState<API.Question[]>([]);
  const [total, setTotal] = useState(0);
  const dispatch = useAppDispatch();
  const [selectedRowKeys, setSelectedRowKeys] = useState<Key[]>([]);

  const user = useAppSelector((state) => state.auth.user);

  const questionTableColumns: ColumnsType<API.Question> = [
    {
      dataIndex: 'index',
      key: 'index',
      width: 48,
    },
    {
      title: 'Type',
      dataIndex: 'questionType',
      key: 'questionType',
    },
    {
      title: 'Question',
      dataIndex: 'questionContent',
      key: 'questionContent',
      width: 500,
      render: (text) => <Editor handleEditorChange={() => null} value={text} />,
    },
  ];

  const getList = async (page: number) => {
    try {
      dispatch(
        retrieveQuestions({
          page,
          userId: user.roles.find((x: string) => x === 'admin') ? '' : user.email,
        })
      ).then((result) => {
        setQuestionList(result.payload.object);
        setTotal(result.payload.total);
      });
    } catch (err) {
      notificationError(MESSAGE_FAILURE);
    }
  };

  useEffect(() => {
    getList(1);
  }, []);

  const paginationChange = (page: number, pageSize?: number) => {
    getList(page);
  };

  const handleSelectButton = () => {
    const selectedQuestion = questionList.filter((x) => {
      if (selectedRowKeys.includes(x.id)) return x;
    });
    handleSelectQuestion(selectedQuestion);
    setSelectedRowKeys([]);
  };

  return (
    <Card>
      <Row justify="end" className="mb-xs">
        <Space>
          <Button type="primary" key="show" onClick={handleSelectButton}>
            Select question
          </Button>
        </Space>
      </Row>
      <Table<API.Question>
        columns={questionTableColumns}
        dataSource={questionList}
        rowKey="id"
        rowSelection={{
          selectedRowKeys,
          onChange: (selectedKeys) => {
            setSelectedRowKeys(selectedKeys);
          },
        }}
        pagination={{
          pageSize: ITEM_PER_PAGE,
          total: total,
          defaultCurrent: 1,
          showSizeChanger: false,
          onChange: paginationChange,
          showTotal: (total, range) => `${range[0]}-${range[1]} of ${total} items`,
        }}
      />
    </Card>
  );
};

export default QuestionTable;
