import { Row } from 'antd';
import { SectionTitle } from 'components/Section';

export const DrivingLawList = (props: any) => {
  return (
    <div id="feature" className="block featureBlock bgGray">
      <div className="container-fluid">
        <div className="titleHolder">
          <SectionTitle>Driving Law!</SectionTitle>
          <p>Laws and Rules of the Road!</p>
        </div>
        <Row gutter={[16, 16]}>{props.children}</Row>
      </div>
    </div>
  );
};
