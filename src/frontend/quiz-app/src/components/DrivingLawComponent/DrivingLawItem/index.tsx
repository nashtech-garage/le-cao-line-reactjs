import { EditOutlined, EllipsisOutlined, SettingOutlined } from '@ant-design/icons';
import { Card, Col, Image, Tooltip } from 'antd';
import { GO_TO_DRIVING_EXAM, GO_TO_DRIVING_LAW } from 'constants/Messages';
import { useNavigate } from 'react-router-dom';
const { Meta } = Card;

export const DrivingLawItem = (props: { drivingLaw: MODEL.IDrivingLaw }) => {
  const { drivingLaw } = props;
  const navigate = useNavigate();
  return (
    <Col xs={{ span: 24 }} sm={{ span: 12 }} md={{ span: 8 }}>
      <Card
        hoverable
        cover={<Image alt={drivingLaw.Title} src={drivingLaw.Image} />}
        actions={[
          <Tooltip placement="bottomRight" title={GO_TO_DRIVING_LAW}>
            <span onClick={() => navigate(`/driving-law/${drivingLaw.Id}`, { replace: true })}>
              <SettingOutlined key="setting" />
            </span>
          </Tooltip>,
          <Tooltip placement="bottomLeft" title={GO_TO_DRIVING_EXAM}>
            <span onClick={() => navigate(`/exams/${drivingLaw.ExamId}/exam`, { replace: true })}>
              <EditOutlined key="edit" />
            </span>
          </Tooltip>,

          <EllipsisOutlined key="ellipsis" />,
        ]}
        title={drivingLaw.Title}
        bordered={false}
      >
        <Meta title={drivingLaw.Title} />
      </Card>
    </Col>
  );
};
