import { DeleteOutlined, EditTwoTone, PlusOutlined, SmileFilled, SmileOutlined } from '@ant-design/icons';
import { Button, Divider, Popconfirm, Row, Space, Spin, Table, Typography } from 'antd';
import { ColumnsType } from 'antd/lib/table';
import { useAppSelector } from 'app/hooks';
import { MESSAGE_FAILURE } from 'constants/Messages';
import { ITEM_PER_PAGE } from 'constants/numberValue';
import { notificationError } from 'helper/Notification';
import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import examManagementApi from 'redux/api/examManagementApi';

const {Paragraph} = Typography;

function ExamList() {
  const [loading, setLoading] = useState<boolean>(false);
  const [examList, setExamList] = useState<API.Exam[]>([]);
  const [total, setTotal] = useState(0);

  const user = useAppSelector((state) => state.auth.user);

  const handleRemoveExam = async (examId: string) => {
    try {
      const res = await examManagementApi.remove(examId);
      if (res.status === 200 || res.status === 201) {
        getList(1);
      }
    } catch (err) {
      notificationError(MESSAGE_FAILURE);
    }
  };

  const examTableColumns: ColumnsType<API.Exam> = [
    {
      dataIndex: 'index',
      key: 'index',
      width: 20,
    },
    {
      title: 'Code',
      dataIndex: 'code',
      key: 'code',
    },
    {
      title: 'Name',
      key: 'examName',
      dataIndex: 'name',
    },
    {
      title: 'Description',
      key: 'description',
      dataIndex: 'description',
    },
    {
      title: 'Action',
      key: 'action',
      render: (text, record) => [
        <div key={record?.id} style={{display:"flex"}}>
          <Popconfirm
            key={`pop_${record.id}`}
            title="Delete"
            onConfirm={() => {
              handleRemoveExam(record.id || '');
            }}
            okText="Yes"
            cancelText="No"
          >
            <Button key={`delete_${record.id}`} type="link" icon={<DeleteOutlined />} danger />
          </Popconfirm>
          <Divider type="vertical" />
          <Link to={`/exams/${record.id}/edit`} key={`link_${record.id}`}>
            <Button key={`edit_${record.id}`} type="link" icon={<EditTwoTone />} />
          </Link>
          <Divider type="vertical" />
          <Paragraph style={{margin:"5px"}} copyable={{
              text: `${window.location.href}/${record.id}/exam`,
              icon: [<SmileOutlined key="copy-icon" />, <SmileFilled key="copied-icon" />],
              tooltips: ['Copy link to visit this exam', 'You clicked!!'],
            }}/>
        </div>,
      ],
    },
  ];

  const getList = async (page: number) => {
    setLoading(true);
    try {
      const res = await examManagementApi.getExams(
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
      <Row justify="end" className="mb-xs">
        <Space>
          <Link to={'/exams/create'} key="createButton">
            <Button type="primary" key="createButton" icon={<PlusOutlined key="createExam" />}>
              <span>Create</span>
            </Button>
          </Link>
        </Space>
      </Row>
      <Table<API.Exam>
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

export default ExamList;
