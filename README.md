# Haacked Woundrous AI Web DEMO

This is a demo of using Open AI in an ASP.NET Core application.

## Setup

You'll need to create an account on https://chat.openai.com/.

Once you have an account, you'll need to create an API key.

Then you'll need to set the following user secrets:

```bash
script/user-secrets set OpenAI:ApiKey $OpenAI_ApiKey
```

And set up the following environment variables:

```bash
OpenAI_OrganizationId={Your org id}
```

This also requires setting up a [GitHub OAuth App](https://github.com/settings/developers) for authentication.

And to enable others to participate, I'm using ngrok: http://bit.ly/haack-ai (redirects to https://devoted-upright-bluejay.ngrok-free.app/) to expose my local web server to the internet.

This also requires setting up a [GitHub OAuth App](https://github.com/settings/developers) for authentication.

You can point that app to https://localhost:7047/signin-github for the callback URL.

To enable others to participate, I'm using ngrok: http://bit.ly/haack-ai (redirects to https://devoted-upright-bluejay.ngrok-free.app/) to expose my local web server to the internet.
If you want to do the same, make sure to set the following environment variable:

```bash
GitHub_Host={Your ngrok host name}
```

## Running

To run the app, you'll need to run the following command:

```bash
script/all -D
overmind connect
```

The -D runs it daemonized. `overmind connect` lets you connect to all the running services in Overmind tabs.

If you want to run it from the IDE, you'll need to run the following command to exclude starting the web server:

```bash
script/all -D -e web
overmind connect
```

Then run the web server from the IDE.

## Notes

This project is set up using Central NuGet Package Management.

I also ran `dotnet user-secrets init --project src/AIDemoWeb/AIDemoWeb.csproj` from the repository root to initialize the user secrets.
