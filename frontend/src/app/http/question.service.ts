import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class QuestionService {
  constructor(private http: HttpClient) {}

  public getQuestions(difficulty: string): Observable<any> {
    return this.http.get(`${environment.serverBaseUrl}questions?difficulty=${difficulty}`);
  }

}
