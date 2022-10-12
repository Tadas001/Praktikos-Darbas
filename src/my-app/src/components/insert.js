
import { useState } from "react";

function refreshPage() {
    window.location.reload(false);
  }

function Insert() {
  const [name, setName] = useState("");
  const [surname, setSurname] = useState("");
  const [birthdate, setBirthdate] = useState("");
  const [email, setEmail] = useState("");
  const [message, setMessage] = useState("");
  const customHeaders = {
    "Content-Type": "application/json",
  }

  let handleSubmit = async (e) => {
    e.preventDefault();
    try {
      let res = await fetch("http://localhost:5059/Users", {
        method: "POST",
        headers: customHeaders,
        body: JSON.stringify({
          name: name,
          surname: surname,
          birthdate: birthdate,
          email: email
        }),
      });
      let resJson = await res.json();
      if (res.status === 200) {
        setName("");
        setSurname("");
        setBirthdate("");
        setMessage("User created successfully");
      } else {
        setMessage("Some error occured");
      }
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <div className="app-container">
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          value={name}
          placeholder="Name"
          onChange={(e) => setName(e.target.value)}
        />
        <input
          type="text"
          value={surname}
          placeholder="Surname"
          onChange={(e) => setSurname(e.target.value)}
        />
        <input
          type="text"
          value={birthdate}
          placeholder="Birthdate"
          onChange={(e) => setBirthdate(e.target.value)}
        />
        <input
          type="text"
          value={email}
          placeholder="Email"
          onChange={(e) => setEmail(e.target.value)}
        />
        <button type="submit" onClick={refreshPage}>Create</button>

        <div className="message">{message ? <p>{message}</p> : null}</div>
      </form>
    </div>
  );
}

export default Insert;
