import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Subject } from 'rxjs';
import { LivescoreOutput, LivescoreOutputItem } from './livescore/livescore.models';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {

  public newLivescoreCreated = new Subject<LivescoreOutput>();
  public livescoreOutput = new Subject<LivescoreOutputItem>();
  private hubConnection: HubConnection;
  private connectionUrl = 'https://localhost:5001/betgrabhub';

  constructor() { }

  connect() {
    this.startConnection();
    this.addListeners();
  }

  sendHello() {
  }

  private getConnection(): HubConnection {
    return new HubConnectionBuilder()
      .withUrl(this.connectionUrl)
      //.withHubProtocol(new MessagePackHubProtocol())
      //  .configureLogging(LogLevel.Trace)
      .build();
  }

  private startConnection() {
    this.hubConnection = this.getConnection();

    this.hubConnection.start()
      .then(() => console.log('connection started'))
      .catch((err) => console.log('error while establishing signalr connection: ' + err))
  }

  private addListeners() {
    this.hubConnection.on("onWriteToLivescoreOutput", (m: LivescoreOutputItem) => { this.livescoreOutput.next(m); });
    this.hubConnection.on("onNewOutput", (o: LivescoreOutput) => { this.newLivescoreCreated.next(o); })
  }
}
