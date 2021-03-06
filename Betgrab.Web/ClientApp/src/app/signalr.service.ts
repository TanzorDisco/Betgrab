import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { Subject } from 'rxjs';
import { LivescoreEventProgressData, LivescoreOutput, LivescoreOutputItem as LivescoreEventMessage } from './livescore/livescore.models';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {

  public livescoreOutputCreated = new Subject<LivescoreOutput>();
  public livescoreEventMessage = new Subject<LivescoreEventMessage>();
  public livescoreEventProgress = new Subject<LivescoreEventProgressData>();
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
    this.hubConnection = this.getConnection()

    this.hubConnection.start()
      .then(() => console.log('connection started'))
      .catch((err) => console.log('error while establishing signalr connection: ' + err))
  }

  private addListeners() {
    this.hubConnection.on("onWriteToLivescoreOutput", (m: LivescoreEventMessage) => { this.livescoreEventMessage.next(m); })
    this.hubConnection.on("onNewOutput", (o: LivescoreOutput) => { this.livescoreOutputCreated.next(o); })
    this.hubConnection.on("onLivescoreEventProgress", (o: LivescoreEventProgressData) => { this.livescoreEventProgress.next(o); })
  }
}
