import { HttpClient, HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { RouterModule } from "@angular/router";
import { ServiceWorkerModule } from "@angular/service-worker";

import { environment } from "../environments/environment";
import { AppComponent } from "./app.component";
import { AppRoutingModule } from "./app.routing";
import { PushsubscriberComponent } from "./components/pushsubscriber/pushsubscriber.component";
import { QuizComponent } from "./components/quiz/quiz.component";
import { MaterialModule } from "./material.module";
import { NewsletterService } from "./services/newsletter.service";
import { QuestionService } from "./services/question.service";

@NgModule({
  declarations: [AppComponent, QuizComponent, PushsubscriberComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MaterialModule,
    ServiceWorkerModule.register("ngsw-worker.js", {
      enabled: environment.production
    }),
    BrowserAnimationsModule
  ],
  exports: [RouterModule],
  providers: [QuestionService, NewsletterService],
  bootstrap: [AppComponent]
})
export class AppModule {}
