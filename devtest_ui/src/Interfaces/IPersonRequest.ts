export interface IPersonRequest {
  FirstName: string;
  LastName: string;
  SocialSkills: string[];
  SocialAccounts: SocialAccount[];
}

interface SocialAccount {
  Type: string;
  Address: string;
}