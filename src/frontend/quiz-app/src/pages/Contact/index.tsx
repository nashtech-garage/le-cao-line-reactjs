import { Button, Form, Image, Input, InputNumber } from 'antd';
import AppContact from 'components/AppContact';
import Section, { SectionBody, SectionTitle } from 'components/Section';

const layout = {
  labelCol: { span: 4 },
  wrapperCol: { span: 16 },
};

/* eslint-disable no-template-curly-in-string */
const validateMessages = {
  required: '${label} is required!',
  types: {
    email: '${label} is not a valid email!',
    number: '${label} is not a valid number!',
  },
  number: {
    range: '${label} must be between ${min} and ${max}',
  },
};
/* eslint-enable no-template-curly-in-string */
function Contact() {
  return (
    <Section>
      <SectionTitle>Contact us</SectionTitle>
      <SectionBody>
        <div className="section__body__left">
          <AppContact />
        </div>
        <div className="section__body__right">
          <Image
            src="error"
            fallback="https://hlxonline.com/images/Group106.png?432d18ac60a35816614c695a2ae5a4fe"
          />
        </div>
      </SectionBody>
    </Section>
  );
}

export default Contact;
