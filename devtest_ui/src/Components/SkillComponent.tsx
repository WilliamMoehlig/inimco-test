import { Field } from "react-final-form";

import { FieldArray } from "react-final-form-arrays";

const SkillComponent = () => {
  return (
    <FieldArray name="skills">
      {({ fields }) =>
        fields.map((name, index) => (
          <div key={name} className="input-group">
            <Field className="form-control"
              name={`${name}`}
              component="input"
              placeholder="Skill"
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

export default SkillComponent;