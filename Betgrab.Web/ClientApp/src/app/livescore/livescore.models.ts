export interface LivescoreOutput {
  id?: string;
  messages?: string[];
  currentEvent?: string;
  progress?: number;
}

export interface LivescoreOutputItem {
  id?: string;
  message?: string;
}

export interface LivescoreEventProgressData {
  id?: string;
  progress?: number;
}