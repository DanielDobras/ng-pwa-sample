import * as rxjs from "rxjs";
import { mapTo } from "rxjs/operators";

import { Injectable } from "@angular/core";
import { SwUpdate } from "@angular/service-worker";

@Injectable({
  providedIn: "root"
})
export class PwaService {
  promptEvent: any;

  isUserOnline = rxjs.merge(
    rxjs.fromEvent(window, "online").pipe(mapTo(true)),
    rxjs.fromEvent(window, "offline").pipe(mapTo(false)),
    rxjs.of(navigator.onLine)
  );

  constructor(private swUpdate: SwUpdate) {
    // checks if an update is available and after it is installed,asks the user to refresh the page.
    swUpdate.available.subscribe(event => {
      if (this.askUserToUpdate()) {
        window.location.reload();
      }
    });

    window.addEventListener("beforeinstallprompt", event => {
      this.promptEvent = event;
    });
  }

  // ask the user if he wants to refresh the page to get the current updates now.
  // for now, every user has to accept the updates ;)
  askUserToUpdate(): boolean {
    return true;
  }
}
