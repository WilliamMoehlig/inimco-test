import { Field } from "react-final-form";

import { FieldArray } from "react-final-form-arrays";

const AccountComponent = () => {
  return (
    <FieldArray name="accounts">
      {({ fields }) =>
        fields.map((name, index) => (
          <div key={name} className="input-group">
            <Field className="form-control"
              name={`${name}.type`}
              component="input"
              placeholder="Type"
            />
            <Field className="form-control"
              name={`${name}.address`}
              component="input"
              placeholder="Address"
            />

            <div className="input-group-append">
              <span className="btn btn-outline-secondary"
                onClick={() => fields.remove(index)}
                style={{ cursor: "pointer" }}
              >
                ❌
              </span>
            </div>
          </div>
        ))
      }
    </FieldArray>
  )
}

export default AccountComponent;