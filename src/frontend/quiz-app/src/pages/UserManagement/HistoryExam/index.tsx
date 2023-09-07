import { EyeOutlined } from '@ant-design/icons';
import { Button, Spin, Table } from 'antd';
import { ColumnsType } from 'antd/lib/table';
import { useAppSelector } from 'app/hooks';
import { MESSAGE_FAILURE } from 'constants/Messages';
import { ITEM_PER_PAGE } from 'constants/numberValue';
import { notificationError } from 'helper/Notification';
import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import examManagementApi from 'redux/api/examManagementApi';

function HistoryExam() {
  const [loading, setLoading] = useState<boolean>(false);
  const [examList, setExamList] = useState<API.ExamResult[]>([]);
  const [total, setTotal] = useState(0);
  const user = useAppSelector((state) => state.auth.user);
  
  const examTableColumns: ColumnsType<API.ExamResult> = [
    {
      dataIndex: 'index',
      key: 'index',
      width: 20,
    },
    {
      title: 'Exam title',
      dataIndex: 'examName',
      key: 'examName',
    },
    {
      title: 'Result',
      dataIndex: 'resultStatus',
      key: 'resultStatus',
    },
    {
      title: 'Corrects',
      key: 'numberOfCorrectAnswer',
      dataIndex: 'numberOfCorrectAnswer',
    },
    {
      title: 'Submit time',
      key: 'createdDate',
      dataIndex: 'createdDate',
      render:(value) => [<div>{new Date(value).toLocaleString()}</div> ]
    },
    {
      title: 'Action',
      key: 'action',
      render: (text, record) => [
        <div key={record?.id}>
          <Link to={`/exams/${record.id}/result`} key={`result_${record.id}`}>
            <Button key={`result_${record.id}`} type="link" icon={<EyeOutlined />} />
          </Link>
        </div>,
      ],
    },
  ];

  const getList = async (page: number) => {
    setLoading(true);
    try {
      const res = await examManagementApi.getExamResults(
        page,
        user.roles.find((x: string) => x === 'admin') ? '' : user.email
      );
      if (res.status === 200) {
        const { object } = res.data;
        setExamList(object.object);
        setTotal(object.total);
      }
    } catch (err) {
      notificationError(MESSAGE_FAILURE);
    }
    setLoading(false);
  };

  useEffect(() => {
    getList(1);
  }, []);

  const paginationChange = (page: number, pageSize?: number) => {
    getList(page);
  };

  return (
    <Spin spinning={loading}>
      <Table<API.ExamResult>
        columns={examTableColumns}
        dataSource={examList}
        pagination={{
          pageSize: ITEM_PER_PAGE,
          total: total,
          defaultCurrent: 1,
          showSizeChanger: false,
          onChange: paginationChange,
          showTotal: (total, range) => `${range[0]}-${range[1]} of ${total} items`,
        }}
      />
    </Spin>
  );
}

export default HistoryExam;
