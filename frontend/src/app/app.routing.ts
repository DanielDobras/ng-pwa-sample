import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { QuizComponent } from "./components/quiz/quiz.component";

const routes: Routes = [
    {
        path: "",
        redirectTo: "quiz",
        pathMatch: "full",

    },
    {
        path: "quiz",
        component: QuizComponent
    }
];

@NgModule({
    exports: [RouterModule],
    imports: [RouterModule.forRoot(routes, { useHash: true })]
})
export class AppRoutingModule {}
