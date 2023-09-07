
import { Col, Row } from 'antd';
import { SectionTitle } from 'components/Section';
import { FcNews, FcPortraitMode, FcReadingEbook } from "react-icons/fc";
const items = [
  {
    key: '1',
    icon: <FcNews />,
    title: "Read the Driver's Manual",
    content: 'We provide the most recent version online. And you study everywhere and every time',
  },
  {
    key: '2',
    icon: <FcPortraitMode />,
    title: 'Take the Exam Simulator',
    content:
      'Designed to feel just like the official exam, the Exam Simulator generates a new set of questions every time you restart it.',
  },
  {
    key: '3',
    icon: <FcReadingEbook />,
    title: 'Take engaging practice tests',
    content: `They cover every section of the driver's manual and literally "over-prepare" you, so the official exam will seem easy.`,
  },
];

function AppAbout() {
  return (
    <div id="about" className="block aboutBlock">
      <div className="container-fluid">
        <div className="titleHolder">
          <SectionTitle>Know More About Us!</SectionTitle>
          <p>Learn driving and traffic rules that make you a better driver</p>
        </div>
        <div className="contentHolder">
          <p>
            We built the website with the purpose of helping you reduce the time in learning your
            driver's license and review your knowledge more easily with law lessons categorized by
            topic. You will experience mock tests with 100% simulated test sets from the real exam.
          </p>
          <strong>Wish you have great experiences!</strong>
        </div>
        <Row gutter={[16, 16]}>
          {items.map((item) => {
            return (
              <Col md={{ span: 8 }} key={item.key}>
                <div className="content">
                  <div className="icon">{item.icon}</div>
                  <h3>{item.title}</h3>
                  <p>{item.content}</p>
                </div>
              </Col>
            );
          })}
        </Row>
      </div>
    </div>
  );
}

export default AppAbout;
