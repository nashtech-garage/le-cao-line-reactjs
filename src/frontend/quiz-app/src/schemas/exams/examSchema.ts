// eslint-disable-next-line import/no-anonymous-default-export
export default {
  formField: {
    name: {
      name: 'name',
      label: 'Exam title',
      errMsg: 'Please input the title of this exam',
      required: true,
      placeholder: '',
    },
    tags: {
      name: 'tags',
      label: 'Related tags',
      placeholder: '',
    },
    description: {
      name: 'description',
      label: 'Exam description',
      errMsg: 'Please input the description of this exam',
      required: true,
      placeholder: '',
    },

    plusScorePerQuestion: {
      name: 'plusScorePerQuestion',
      label: 'Plus score per question',
    },
    minusScorePerQuestion: {
      name: 'minusScorePerQuestion',
      label: 'Minus score per question',
    },
    timePerQuestion: {
      name: 'timePerQuestion',
      label: 'Time per question',
    },
    shufflingExams: {
      name: 'shufflingExams',
      label: 'Shuffling exams',
    },
    percentageToPass: {
      name: 'percentageToPass',
      label: 'Percentage to pass',
    },

    viewPassQuestion: {
      name: 'viewPassQuestion',
      label: 'View pass question',
    },
    viewNextQuestion: {
      name: 'viewNextQuestion',
      label: 'View next question',
    },
    showAllQuestion: {
      name: 'showAllQuestion',
      label: 'Show all question',
    },
    hideResult: {
      name: 'hideResult',
      label: 'Hide result',
    },

    questionList: {
      name: 'questions',
      required: true,
      errMsg: 'This exam need at least one question',
    },

    scheduleList: {
      name: 'schedules',
      required: true,
      errMsg: 'This exam need at least one schedule',
    },

    setting: {
      name: 'setting',
    },
  },
};
