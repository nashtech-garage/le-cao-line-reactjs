import { Image } from 'antd';
import AppAbout from 'components/AppAbout';
import Heading, { HeadingMedium } from 'components/Heading';
import Section, { SectionBody, SectionTitle } from 'components/Section';
function AboutUs() {
  return (
    <Section>
      {/* <SectionTitle>Hiểu Hơn Về Chúng Tôi!</SectionTitle> */}
      <SectionBody>
        <div className="section__body__left">
          <AppAbout />
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

export default AboutUs;
