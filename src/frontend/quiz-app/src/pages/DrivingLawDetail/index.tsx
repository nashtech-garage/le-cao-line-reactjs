import Section, { SectionBody, SectionTitle } from 'components/Section';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import masterData from '../../masterData.json';
import { Image } from 'antd';

function DrivingLawDetail() {
  const [law, setLaw] = useState<MODEL.IDrivingLaw>({
    Id: 0,
    Title: '',
    Content: '',
    Image: '',
    Thumb: '',
    ExamId: '',
  });
  const { drivingLawId } = useParams();

  useEffect(() => {
    let result = null;
    if (drivingLawId) {
      result = masterData[0]['driving-law']?.find(
        (drivingLaw) => drivingLaw.Id === parseInt(drivingLawId)
      );
      result && setLaw(result);
    }
  }, []);

  return (
    <>
      {law && (
        <Section>
          <SectionTitle>{law.Title}</SectionTitle>
          <SectionBody>
            <div style={{ flex: 1 }}>
              <div className="section__image-law">
                <Image src={law.Thumb} alt="" />
              </div>
              <div className="section__text">
                <div className="section__text__desc">
                  <p>
                    Bộ đề sát hạch cấp giấy phép lái xe hạng A1 gồm 25 câu với thời gian làm bài là
                    19 phút trong đó:
                  </p>
                  <p>Có 01 câu về khái niệm;</p>
                  <p>01 câu hỏi về tình huống mất an toàn giao thông nghiêm trọng;</p>
                  <p>06 câu về quy tắc giao thông;</p>
                  <p>01 câu về tốc độ, khoảng cách;</p>
                  <p>01 câu về văn hóa giao thông và đạo đức người lái xe;</p>
                  <p>01 câu về kỹ thuật lái xe;</p>
                  <p>01 câu về cấu tạo sửa chữa;</p>
                  <p>07 câu về hệ thống biển báo đường bộ;</p>
                  <p>07 câu về giải các thế sa hình và kỹ năng xử lý tình huống giao thông.</p>
                </div>
              </div>
            </div>
          </SectionBody>
        </Section>
      )}
    </>
  );
}

export default DrivingLawDetail;
