import { useState } from "react";
import axios, { AxiosRequestConfig, AxiosResponse } from "axios";

import { Form } from "react-final-form";
import arrayMutators from "final-form-arrays";

import { IPersonResponse } from "../Interfaces/IPersonResponse";
import { IPersonRequest } from "../Interfaces/IPersonRequest";
import SkillComponent from "./SkillComponent";
import AccountComponent from "./AccountComponent";

const PersonComponent = () => {
  const config: AxiosRequestConfig = {
    headers: {
      "X-API-KEY": "aW5pbWNv",
      "Content-Type": "application/json"
    }
  }

  const [firstName, setFirstName] = useState<string>("");
  const [lastName, setLastName] = useState<string>("");
  const [personResponse, setPersonResponse] = useState<IPersonResponse>();

  const PostPerson = async (request: IPersonRequest) => {
    const { data }: AxiosResponse<IPersonResponse> = await axios.post("https://localhost:44392/person", request, config);

    setPersonResponse(data);
  }

  const OnSubmit = async (evt: any) => {

    var request: IPersonRequest = {
      FirstName: firstName,
      LastName: lastName,
      SocialSkills: evt.skills,
      SocialAccounts: evt.accounts
    };

    await PostPerson(request);
  }

  const enabled: boolean = firstName.length > 0 && lastName.length > 0;

  return (
    <>
      <Form
        onSubmit={OnSubmit}
        mutators={{
          ...arrayMutators
        }}
        render={({
          handleSubmit,
          form: {
            mutators: { push }
          }
        }) => {
          return (
            <form onSubmit={handleSubmit}>
              <div className="mb-3">
                <label htmlFor="firstname" className="form-label">
                  First Name:
                </label>
                <input id="firstname" className="form-control"
                  type="text"
                  value={firstName}
                  onChange={e => setFirstName(e.target.value)}
                />
              </div>
              <label htmlFor="lastname" className="form-label">
                Last Name:
              </label>
              <input id="lastname" className="form-control"
                type="text"
                value={lastName}
                onChange={e => setLastName(e.target.value)}
              />
              <div className="buttons">
                <button className="btn btn-outline-primary"
                  type="button"
                  onClick={() => push("skills", undefined)}
                >
                  + Social Skills
                </button>
              </div>
              <SkillComponent />
              <div className="buttons">
                <button className="btn btn-outline-primary"
                  type="button"
                  onClick={() => push("accounts", undefined)}
                >
                  + Social Accounts
                </button>
              </div>
              <AccountComponent />
              <div className="buttons">
                <input type="submit" disabled={!enabled} value="Submit" className="btn btn-outline-primary" />
              </div>
            </form>
          );
        }}
      />
      <div className="jumbotron">
        <p className="lead">
          The number of VOWELS: {personResponse?.numberOfVowels} <br />
          The number of CONSONANTS: {personResponse?.numberOfConsonants} <br />
          The firstname + lastname entered: {personResponse?.name} <br />
          The reverse version of the firstname and lastname: {personResponse?.reverseName} <br />
          The JSON format of the entire object: <br />
          {personResponse?.jsonFormat} <br />
        </p>

      </div>
    </>
  )
}

export default PersonComponent;