import React from "react";
import NavBar from "./NavBar";
NavBar
const FAQ = () => {
  return (
    <div>
        <h2>Frequently Asked Questions</h2>
        <Accordion defaultActiveKey="0">
            <Accordion.Item eventKey="0">
            <Accordion.Header>Is this an online-only charity?</Accordion.Header>
            <Accordion.Body>
                Yes.
            </Accordion.Body>
            </Accordion.Item>
        <Accordion.Item eventKey="1">
            <Accordion.Header>What kind of pets do you specialize in?</Accordion.Header>
            <Accordion.Body>
                Dogs and cats are our specialty. They are adorable, after all!
            </Accordion.Body>
            </Accordion.Item>
        <Accordion.Item eventKey="2">
            <Accordion.Header>Do I need a lot of experience with pets?</Accordion.Header>
            <Accordion.Body>
                We at Pet Heaven strive to provide for both veteran owners and those just starting out!
            </Accordion.Body>
            </Accordion.Item>
        </Accordion>
    </div>
    );
};

export default FAQ;