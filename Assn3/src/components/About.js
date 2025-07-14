import React from "react";
import NavBar from "./NavBar";
NavBar
const About = () => {
  return (
    <div>
      <h2>About</h2>
      <img
        styles={{ minWidth: 500, minHeight: 500 }}
        src = "https://www.usatoday.com/money/blueprint/images/uploads/2023/06/27134316/best-pet-insurance-scaled-e1687873423254.jpg"
      />
      <p>
        We're a charity that takes care of abandoned pets, ensuring that their welfare is maintained.
        If you're interested in taking care of these adorable friends or donating your own, simply make use of our adoption form.
        We'll get you started from there!
      </p>
      <h2>Contacts</h2>
      <p>Facebook: </p>
      <p>Twitter: </p>
      <p>Instagram: </p>
      <footer>
        <p>&copy; 2023 Pet Heaven. All rights reserved</p>
      </footer>  
    </div>
  );
};

export default About;
