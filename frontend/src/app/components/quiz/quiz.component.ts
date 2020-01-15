import { QuestionService } from "src/app/http/question.service";
import { Question } from "src/app/models/question";

import { Component, OnInit } from "@angular/core";
import { DomSanitizer, SafeUrl } from "@angular/platform-browser";

@Component({
  selector: "app-quiz",
  templateUrl: "./quiz.component.html",
  styleUrls: ["./quiz.component.scss"]
})
export class QuizComponent implements OnInit {
  public questions: Array<Question>;
  public quizStarted: boolean;
  public currentQuestion: Question;
  public currentCounter = 0;
  public results: Array<boolean>;
  public imageUrl: SafeUrl;
  public quizFinished: boolean;
  public answers: Array<boolean>;
  public correctAnswers: number;
  public correctPercentage: any;
  public isLoading: boolean;

  constructor(
    private questionService: QuestionService,
    private domSanitizer: DomSanitizer
  ) {}

  ngOnInit() {}

  public getQuestions(difficulty: string) {
    this.isLoading = true;
    this.questionService.getQuestions(difficulty).subscribe(
      response => {
        this.currentCounter = 0;
        this.questions = response;
        this.quizStarted = true;
        this.currentQuestion = this.questions[this.currentCounter];
        this.convertImage();
        this.currentCounter++;
        this.answers = new Array<boolean>();
        this.isLoading = false;
      },
      error => {
        this.isLoading = false;
        console.log(error);
      }
    );
  }

  public nextQuestion(answer: boolean) {
    // check answer
    this.answers.push(this.currentQuestion.isBird === answer);

    // last question has been reached
    if (this.currentCounter === this.questions.length) {
      this.quizStarted = false;
      this.quizFinished = true;
      this.generateQuizResult();
    } else {     // go to the next question
      this.currentQuestion = this.questions[this.currentCounter];
      this.currentCounter++;
      this.convertImage();
    }
  }

  public convertImage() {

    this.imageUrl = this.domSanitizer.bypassSecurityTrustResourceUrl(
      "data:image/jpg;base64, " + this.currentQuestion.image
    );
  }

  public generateQuizResult() {
    this.correctAnswers = this.answers.filter(x => x === true).length;
    this.correctPercentage = (this.correctAnswers / this.questions.length) * 100;
  }

  public resetGame() {
    this.questions = null;
    this.quizStarted = false;
    this.quizFinished = false;
  }
}
