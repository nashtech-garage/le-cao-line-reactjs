import examFields from './examSchema';

const {
  formField: {
    name,
    description,
    tags,
    setting,
    questionList,
    scheduleList,
    plusScorePerQuestion,
    minusScorePerQuestion,
    timePerQuestion,
    shufflingExams,
    percentageToPass,
    viewPassQuestion,
    viewNextQuestion,
    showAllQuestion,
    hideResult,
  },
} = examFields;

export function getInitialValue(objectInfo?: API.Exam) {
  return {
    [name.name]: (objectInfo && objectInfo.name) || '',
    [description.name]: (objectInfo && objectInfo.description) || '',
    [tags.name]: (objectInfo && objectInfo.tags) || [],
    [questionList.name]: (objectInfo && objectInfo.questions) || [],
    [scheduleList.name]: (objectInfo && objectInfo.schedules) || [],
    [plusScorePerQuestion.name]:
      (objectInfo && objectInfo.plusScorePerQuestion) || 0,
    [minusScorePerQuestion.name]:
      (objectInfo && objectInfo.minusScorePerQuestion) || 0,
    [timePerQuestion.name]: (objectInfo && objectInfo.timePerQuestion) || 0,
    [shufflingExams.name]: (objectInfo && objectInfo.shufflingExams) || 0,
    [percentageToPass.name]:
      (objectInfo && objectInfo.percentageToPass) || 50,
    [viewPassQuestion.name]:
      (objectInfo && objectInfo.viewPassQuestion) || true,
    [viewNextQuestion.name]:
      (objectInfo && objectInfo.viewNextQuestion) || true,
    [showAllQuestion.name]:
      (objectInfo && objectInfo.showAllQuestion) || false,
    [hideResult.name]: (objectInfo && objectInfo.hideResult) || true,
  };
}
