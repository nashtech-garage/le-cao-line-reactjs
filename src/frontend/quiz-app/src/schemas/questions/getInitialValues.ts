
import { HEURISTIC_LEVEL, MAP_HEURISTIC_LEVEL_ID } from 'constants/exam';
import questionFields from './questionSchema';

const {
  formField: { question, options, shuffleAnswers, heuristicLevel },
} = questionFields;

export function getInitialValue(questionInfo?: API.Question) {
  const answers = questionInfo?.answers.map(x=> {return {...x, answerValue:x.answerValue.toLowerCase() === "true" }});
  return {
    [question.name]: (questionInfo && questionInfo.questionContent) || '',
    [options.name]: (questionInfo && answers) || [],
    [shuffleAnswers.name]: (questionInfo && questionInfo.shuffleAnswers) || false,
    [heuristicLevel.name]: (questionInfo && questionInfo.levelId) || MAP_HEURISTIC_LEVEL_ID[HEURISTIC_LEVEL.KNOWLEDGE],
  };
}
