import { useState } from "react";
import axios, { AxiosRequestConfig, AxiosResponse } from "axios";

import { IPersonResponse } from "../Interfaces/IPersonResponse";
import { IPersonRequest, SocialAccount } from "../Interfaces/IPersonRequest";

const PersonComponent = () => {
  const config: AxiosRequestConfig = {
    headers: {
      "X-API-KEY": "aW5pbWNv",
      "Content-Type": "application/json"
    }
  }

  const [firstName, setFirstName] = useState<string>("");
  const [lastName, setLastName] = useState<string>("");
  const [socialSkills, setSocialSkills] = useState<string[]>([]);
  const [socialAccounts, setSocialAccounts] = useState<SocialAccount[]>([]);

  const PostPerson = async (request: IPersonRequest) => {
    const { data }: AxiosResponse<IPersonResponse> = await axios.post("https://localhost:44392/person", request, config);

    alert(data);
  }

  const handleSubmit = async (evt: any) => {
    evt.preventDefault();

    var request: IPersonRequest = {
      FirstName: firstName,
      LastName: lastName,
      SocialSkills: socialSkills,
      SocialAccounts: socialAccounts
    };

    await PostPerson(request);
  }

  return (
    <>
      <form onSubmit={handleSubmit}>
        <label>
          First Name:
          <input
            type="text"
            value={firstName}
            onChange={e => setFirstName(e.target.value)}
          />
        </label>
        <label>
          Last Name:
          <input
            type="text"
            value={lastName}
            onChange={e => setLastName(e.target.value)}
          />
        </label>
        <input type="submit" value="Submit" />
      </form>
    </>
  )
}

export default PersonComponent;