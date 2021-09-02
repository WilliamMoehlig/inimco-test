export interface IPersonRequest {
  FirstName: string;
  LastName: string;
  SocialSkills: string[];
  SocialAccounts: SocialAccount[];
}

export interface SocialAccount {
  Type: string;
  Address: string;
}