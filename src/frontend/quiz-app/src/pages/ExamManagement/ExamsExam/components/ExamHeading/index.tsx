import { HeartOutlined, SaveOutlined, SendOutlined, FlagOutlined } from '@ant-design/icons';
import { Button, Card, Row, Space, Typography } from 'antd';

const { Title, Text } = Typography;

interface Props {
  templateExam: API.Exam | undefined;
  time: number | undefined;
}

const ExamHeading: React.FC<Props> = ({ templateExam, time }) => {
  return (
    <Card className="exam-heading" style={{ backgroundColor: '#003a8c', border: 0 }}>
      <Space align="center" direction="vertical" style={{ display: 'flex' }}>
        <Title level={4} style={{ color: '#ffffff' }}>
          {templateExam?.description?.toUpperCase()}
        </Title>
        <Title level={5} style={{ color: '#ffffff' }}>
          Exam : {templateExam?.name}
        </Title>
        <Title level={5} style={{ color: '#ffffff' }}>
          Time: {time|| 15} minutes
        </Title>
      </Space>

      <Row justify="space-between">
        <Space>
          <Button icon={<HeartOutlined />}>
            <Text strong>Love</Text>
          </Button>
          <Button icon={<SaveOutlined />}>
            <Text strong>Save</Text>
          </Button>
          <Button icon={<SendOutlined />}>
            <Text strong>Share</Text>
          </Button>
        </Space>
        <Button icon={<FlagOutlined />} danger>
          <Text strong>Report</Text>
        </Button>
      </Row>
    </Card>
  );
};

export default ExamHeading;
