<h1 align="center">
  <br>
  <img src="/SubtitleSeparator.png" alt="Markdownify" width="64">
  <br>
  Subtitle Separator
  <br>
</h1>

<h4 align="center">Separating Subtitles for Voice Actors</h4>



Subtitle Seperator
Description
This C# project is designed to streamline the process of separating .srt files for voice artists. If you work with subtitles and need a convenient way to split them for different voice actors, this tool is here to help.

Features
Subtitle Separation: The main functionality of the project is to take .srt files and separate them based on specified criteria for different voice artists.

Customization: Users can customize the separation criteria, such as the duration of subtitles assigned to each voice artist or any other relevant parameter.

Easy-to-Use: The project provides a simple and intuitive user interface to make the separation process user-friendly.

Prerequisites
.NET Core SDK Installation Guide
Installation
Clone the repository to your local machine:

bash
Copy code
git clone https://github.com/your-username/your-repository.git
Navigate to the project directory:

bash
Copy code
cd your-repository
Build the project:

bash
Copy code
dotnet build
Usage
Run the application:

bash
Copy code
dotnet run
Follow the on-screen instructions to provide the necessary input, such as the path to the .srt file and the criteria for separating subtitles.

The separated subtitle files for each voice artist will be generated in the specified output directory.

Configuration
Adjust the configuration file appsettings.json to customize the behavior of the application.

json
Copy code
{
  "SubtitleSettings": {
    "MaxDurationPerArtist": 300,   // Maximum duration of subtitles per voice artist in seconds
    "OutputDirectory": "Output"    // Directory where separated subtitle files will be saved
  }
}
Contributing
If you'd like to contribute to this project, please follow these steps:

Fork the repository.
Create a new branch for your feature or bug fix.
Make your changes and submit a pull request.
License
This project is licensed under the MIT License - see the LICENSE.md file for details.

Acknowledgments
Thanks to [Contributor Name] for their contribution to [specific feature or improvement].
Contact
For any questions or feedback, feel free to reach out to [your-email@example.com].

Happy Subtitle Separation!
