<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $to = "nmorrow@guitartabconverter.com"; // Replace with your email address
    $subject = "Form Submission";
    $message = "Name: " . $_POST["name"] . "\n";
    $message .= "Email: " . $_POST["email"] . "\n";
    $message .= "Message: " . $_POST["message"];
    $headers = "From: " . $_POST["email"];

    if (mail($to, $subject, $message, $headers)) {
        echo "Email sent successfully!";
    } else {
        echo "Error: Unable to send email.";
    }
}
?>
