import { Button, Collapse } from 'antd';
import { useNavigate } from 'react-router-dom';
const { Panel } = Collapse;

function AppFaq() {
  const navigate = useNavigate();
  return (
    <div id="faq" className="block faqBlock">
      <div className="container-fluid">
        <div className="titleHolder">
          <h2>Frequently Asked Questions</h2>
          <p>Common Driving Test Questions to Help You Pass</p>
        </div>
        <Collapse
          defaultActiveKey={['1']}
        >
          <Panel
            header="What is an A1 driver's license (A1 driver's license)? Differentiate by A1 and A2?"
            key="1"
          >
            <p>
              A1 driver's license, also known as A1 driving license, is the lowest basic class of
              driving licenses, used for drivers to operate two-wheeled motorcycles with a cylinder
              capacity from 50cm3 to less than 175cm3 and disabled people operate tricycles used for
              disabled people. Unlike A1, holders of A2 driver's licenses are allowed to operate
              motorcycles with engines of 175 cc or more. To determine the class of the license, the
              owner looks at the front of the driver's license, in the "Class/Class" section it will
              clearly state "A1" or "A2".
            </p>
          </Panel>
          <Panel header="Who needs to take a drivers ed course?" key="2">
            <p>
              Most states require teens between the ages of 15 and 18 to complete a driver education
              program before they can get a learners permit or drivers license.
            </p>
          </Panel>
          <Panel header="Tips to learn theory 600 questions easiest to remember?" key="3">
            <p>
              To help candidates gain more experience in the theory test, TracNghiem.VN synthesizes
              the latest b2 theory learning tips that are easy to remember, ensuring to help you
              pass the theory test extremely easily. See Details of theory learning tips
            </p>
          </Panel>
          <Panel header="Are the practice exams really free?" key="4">
            <p>
              Absolutely! You'll be able to access your practice exam right from your student
              account.
            </p>
          </Panel>
          <Panel header="I have more questions. What do I do?" key="5">
            <p>
              Our driver education experts are here 24 hours a day, 7 days a week to assist you in
              any way. If you have any questions that weren't answered here, please Contact Us at
              any time!
            </p>
          </Panel>
        </Collapse>
        <div className="quickSupport">
          <h3>Want quick support?</h3>
          <p>
            Our driver education experts are here 24 hours a day, 7 days a week to assist you in any
            way. If you have any questions that weren't answered here, please Contact Us at any
            time!
          </p>
          <Button
            type="primary"
            size="large"
            onClick={() => {
              navigate('/contact', { replace: true });
            }}
          >
            Email your question
          </Button>
        </div>
      </div>
    </div>
  );
}

export default AppFaq;
