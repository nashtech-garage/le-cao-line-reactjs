// eslint-disable-next-line import/no-anonymous-default-export
export default {
  formField: {
    question: {
      name: 'questionContent',
      label: 'Question',
      errMsg: 'Please input the content of question',
      required: true,
    },

    options: {
      name: 'answers',
    },

    option: {
      name: 'answerContent',
      label: 'Option',
      errMsg: 'Please input the option of question',
      required: true,
    },

    heuristicLevel: {
      name: 'levelId',
      label: 'Level',
    },

    tags: {
      name: 'tags',
      label: 'Tags',
    },

    value: {
      name: 'answerValue',
      label: 'Correct Option',
    },

    shuffleAnswers: {
      name: 'shuffleAnswers',
      label: 'Shuffle answers',
    },

    order: {
      name: 'id',
      label: 'Order',
    },
  },
};
