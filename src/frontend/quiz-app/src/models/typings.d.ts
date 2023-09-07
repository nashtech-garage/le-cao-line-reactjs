// @ts-ignore
/* eslint-disable */

declare namespace API {
  type Question = {
    id: string;
    questionContent: string;
    shuffleAnswers:boolean;
    questionTypeId?: string;
    levelId?: string;
    userId?: string;
    answers: Option[];
  };

  type QuestionType = {
    id: string;
    name: string;
    description: string;
  }

  type filter = {
    filterType: number,
    filterValue: string
  }

  type filters = {
    keyword: filter,
    questionType: filter,
    createdDate: filter
    level: filter,
    tag: filter
  }

  type PageQuery = {
    page: number,
    pageSize: number,
    query?: filters
  };

  type Exam = {
    id?: string;
    code: string;
    name: string;
    tags: string[];
    description: string;
    defaultQuestionNumber: number;
    type: string;
    questionBankType: string;
    questions: string[] | Question[];
    plusScorePerQuestion: number;
    minusScorePerQuestion: number;
    viewPassQuestion: boolean;
    viewNextQuestion: boolean;
    showAllQuestion: boolean;
    timePerQuestion: number;
    shufflingExams: number;
    hideResult: boolean;
    percentageToPass: number;
    schedules: Schedule[];
  };

  type Schedule = {
    code: string;
    time?: number;
    startTime: Date;
    endTime: Date;
    status: string;
    assignedGroup?: string[];
  };

  type Option = {
    id?:string
    answerContent: string;
    answerValue: any;
    matchingPosition?: number;
  };

  //Submit exam
  type SubmitExamData = {
    answers: QuestionAnswer[];
  };

  type QuestionAnswer = {
    questionId: string;
    answerId: string;
    answerValue?: any;
  };

  //Get exam
  type UserExam = {
    id: string;
    templateExam: TemplateExam;
    user: User;
    setting: Setting;
    code: string;
    name: string;
    description: string;
    type: string;
    status: string;
    scheduleCode: string;
    score: number;
    total: number;
    resultStatus: string;
    questions: QuestionAnswerGet[];
    createdAt: Date;
    updatedAt: Date;
  };

  type QuestionAnswerGet = {
    question: Question;
    answerOrder: number;
    answerValue: any;
  };

  type TemplateExam = {
    id: string;
    code: string;
    name: string;
    description: string;
    defaultQuestionNumber: number;
    time: number;
    type: string;
    questionBankType: string;
    questions: Question[];
    setting: Setting;
    schedules: Schedule[];
    createdAt: Date;
    updatedAt: Date;
    createdBy: User;
    updatedBy: User;
  };

  type ExamResult = {
    id?: string;
    examName?: string;
    examDescription?: string;
    examId: string;
    userId: string;
    resultStatus: string;
    numberOfCorrectAnswer: number;
    createdDate: Date;
    questionAnswers: QuestionAnswer[];
    questions: Question[];
  }
}
declare namespace MODEL {
  type MenuElement = {
    key: string;
    path: string;
    label: string;
    icon: any;
    children?: MenuElement[];
    permission: string[];
  }
  
  type RouteElement = {
    path: string;
    main: any;
    pathComponent?: string;
    permission: string[];
  }
  type IDrivingLaw = {
    Id: number;
    Content: string;
    Image: string;
    Thumb: string;
    Title: string;
    ExamId: string;
  }
}
