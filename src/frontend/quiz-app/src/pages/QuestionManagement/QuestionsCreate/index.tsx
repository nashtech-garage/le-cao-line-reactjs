import { PageContainer, ProCard, ProFormRadio } from '@ant-design/pro-components';
import { Breadcrumb } from 'antd';
import { MAP_QUESTION_TYPE, QUESTION_TYPE } from 'constants/exam';
import { useState } from 'react';
import { Link, Route, Routes, useLocation } from 'react-router-dom';
import QuestionManagement from '..';
import MultipleChoiceQuestionForm from '../FormMultipleChoiceQuestion';

const QuestionCreationPage: React.FC = () => {
  const location = useLocation();
  const [selectedType, setSelectedType] = useState(QUESTION_TYPE.MULTIPLE_CHOICE_QUESTION);
  const mapQuestionTypeOptions = Object.keys(MAP_QUESTION_TYPE).map((type: string) => ({
    value: type,
    label: MAP_QUESTION_TYPE[type],
  }));

  const breadcrumbNameMap: any = {
    '/question-management': 'Question Management',
    '/question-management/add-question': 'Add Question',
    '/question-management/edit-question': 'Edit Question',
  };

  const pathSnippets = location.pathname.split('/').filter((i) => i);
  const extraBreadcrumbItems = pathSnippets.map((_, index) => {
    const url: any = `/${pathSnippets.slice(0, index + 1).join('/')}`;
    return (
      <Breadcrumb.Item key={url}>
        <Link to={url}> {breadcrumbNameMap[url]}</Link>
      </Breadcrumb.Item>
    );
  });
  const breadcrumbItems = [<Breadcrumb.Item key="question-management"></Breadcrumb.Item>].concat(
    extraBreadcrumbItems
  );
  return (
    <PageContainer>
      <div className="demo">
        <Routes>
          <Route path="/question-management" element={<QuestionManagement />} />
        </Routes>
        <Breadcrumb>{breadcrumbItems}</Breadcrumb>
      </div>
      <ProCard>
        <>
          <ProFormRadio.Group
            disabled={true}
            style={{
              margin: 16,
            }}
            radioType="button"
            fieldProps={{
              value: selectedType,
              onChange: (e: any) => setSelectedType(e.target.value),
            }}
            options={mapQuestionTypeOptions}
          />
          {selectedType === QUESTION_TYPE.MULTIPLE_CHOICE_QUESTION && (
            <MultipleChoiceQuestionForm />
          )}
        </>
      </ProCard>
    </PageContainer>
  );
};

export default QuestionCreationPage;
