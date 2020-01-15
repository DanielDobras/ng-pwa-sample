import { environment } from "src/environments/environment";

import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Component, Inject } from "@angular/core";
import { SwPush } from "@angular/service-worker";

@Component({
  selector: "app-pushsubscriber",
  templateUrl: "./pushsubscriber.component.html",
  styleUrls: ["./pushsubscriber.component.scss"]
})
export class PushsubscriberComponent {
  private serverEndpoint = environment.serverBaseUrl;
  readonly httpOptions = {
    headers: new HttpHeaders({
      "Content-Type": "application/json"
    })
  };

  private subscription: PushSubscription;
  public isServiceWorkerSupported: boolean;

  public operationName: string;

  constructor(private swPush: SwPush, private httpClient: HttpClient) {
    swPush.subscription.subscribe(subscription => {
      this.isServiceWorkerSupported = true;
      this.subscription = subscription;
      this.operationName =
        this.subscription === null ? "Subscribe" : "Unsubscribe";
    });
  }

  operation() {
    this.subscription === null
      ? this.subscribe()
      : this.unsubscribe(this.subscription.endpoint);
  }

  private subscribe() {
    this.swPush
      .requestSubscription({
        serverPublicKey: environment.vapidPublicKey
      })
      .then(subscription =>
        this.httpClient
          .post(
            this.serverEndpoint + "PushSubscriptions",
            subscription,
            this.httpOptions
          )
          .subscribe(
            () => {},
            error => console.error(error)
          )
      )
      .catch(error => console.error(error));
  }

  private unsubscribe(endpoint) {
    this.swPush
      .unsubscribe()
      .then(() =>
        this.httpClient
          .delete(
            this.serverEndpoint +
              "PushSubscriptions/" +
              encodeURIComponent(endpoint)
          )
          .subscribe(
            () => {},
            error => console.error(error)
          )
      )
      .catch(error => console.error(error));
  }
}
