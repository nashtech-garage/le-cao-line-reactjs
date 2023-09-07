import { Card } from 'antd';
import { DrivingLawItem } from 'components/DrivingLawComponent/DrivingLawItem';
import { DrivingLawList } from 'components/DrivingLawComponent/DrivingLawList';
import Section from 'components/Section';
import masterData from '../../masterData.json';
const { Meta } = Card;

function DrivingLawComponent() {
  const showListDrivingLaw = () => {
    let result = null;
    result = masterData[0]['driving-law']?.map((drivingLaw: MODEL.IDrivingLaw) => {
      return <DrivingLawItem drivingLaw={drivingLaw} key={drivingLaw.Id} />;
    });
    return result;
  };
  return (
    <Section>
      <DrivingLawList>{showListDrivingLaw()}</DrivingLawList>
    </Section>
  );
}

export default DrivingLawComponent;
