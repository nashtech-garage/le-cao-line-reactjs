import AppAbout from 'components/AppAbout';
import AppContact from 'components/AppContact';
import AppFaq from 'components/AppFaq';
import HeroSlide from 'components/AppHeroSlide';
import AppExam from 'components/AppExam';
import DrivingLawComponent from 'components/DrivingLawComponent';
export default function Home() {
  return (
    <>
      <HeroSlide />
      <AppAbout />
      <DrivingLawComponent />
      {/* <AppWorks /> */}
      <AppFaq />
      {/* <AppExam /> */}
      <AppContact />
    </>
  );
}
