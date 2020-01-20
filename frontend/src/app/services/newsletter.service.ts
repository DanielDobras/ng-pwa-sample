import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class NewsletterService {
  constructor(private http: HttpClient) {}

  addPushSubscriber(sub: any) {
    return this.http.post("/api/notifications", sub);
  }
}
