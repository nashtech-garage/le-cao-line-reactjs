import { Button, Card, Col, Row } from 'antd';
import masterData from '../../masterData.json';
const { Meta } = Card;

function AppExam() {
  const showListDriving = () => {
    let result = null;
    result = masterData[0]['driving-law']?.map((drivingLaw: MODEL.IDrivingLaw) => {
      return (
        <Col span={8}>
          <Card title={drivingLaw.Title} style={{ width: 300, marginTop: 16 }}>
            <Meta description="Number of test takers: 16" style={{ marginBottom: 16 }} />
            <Button type="primary" size="middle">
              <i className="fab fa-telegram-plane"></i> Get Started
            </Button>{' '}
          </Card>
        </Col>
      );
    });
    return result;
  };
  return (
    <div id="statistical" className="block pricingBlock bgGray">
      <div className="container-fluid">
        <div className="titleHolder">
          <h2>Choose a exam to fit your needs</h2>
          <p>You can choose the type of driving license you want to test below.</p>
        </div>
        <Row>
          {showListDriving()}
        </Row>
      </div>
    </div>
  );
}
{
}

export default AppExam;
