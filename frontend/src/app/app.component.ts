import { environment } from "src/environments/environment";

import { Component, OnInit } from "@angular/core";
import { SwPush } from "@angular/service-worker";

import { NewsletterService } from "./services/newsletter.service";
import { PwaService } from "./services/pwa.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"]
})
export class AppComponent implements OnInit {
  isUserOnline: boolean;

  readonly VAPID_PUBLIC_KEY = environment.vapidPublicKey;

  constructor(
    public pwaService: PwaService,
    private swPush: SwPush,
    private newsletterService: NewsletterService
  ) {
    this.pwaService.isUserOnline.subscribe(isOnline => {
      this.isUserOnline = isOnline;
      console.log(isOnline);
    });
  }

  ngOnInit() {}

  installPwa(): void {
    this.pwaService.promptEvent.prompt();
  }

  subscribeToNotifications(): void {
    this.swPush
      .requestSubscription({
        serverPublicKey: this.VAPID_PUBLIC_KEY
      })
      .then(sub => this.newsletterService.addPushSubscriber(sub).subscribe())
      .catch(err => console.error("Could not subscribe to notifications", err));
  }
}
