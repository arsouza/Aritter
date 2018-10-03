# Contributing

We are excited to have you working on the project and cordially request that you follow the Guidelines:

- [Code Style Guidelines](#coding-rules)
- [Commit Message Guidelines](#git-commit-guidelines)

## Coding Rules

To ensure consistency throughout the source code, keep these rules in mind as you are working:

- All features or bug fixes **must pass all tests**

## Git Commit Guidelines

We have very precise rules over how our git commit messages can be formatted for maintenance of the changelog and semvar versioning. This leads to **more readable messages** that are easy to follow when looking through the **project history**.  But also, we use the git commit messages to **generate the change log**.

## Recommended workflow

1. Start new gitflow feature
2. Make changes
3. Run `dotnet test` to run unit tests for all projects.
4. Commit changes using the commit message conventions below.
5. Push

## Commit Message Format

Each commit message includes a **type**, a **scope** and a **subject**:

```#!/text
<type>(<scope>): <subject>
```

The **type** and **subject** are mandatory and the **scope** is optional.

Any line of the commit message cannot be longer 100 characters! This allows the message to be easier to read on GitHub as well as in various git tools.

## Revert

If the commit reverts a previous commit, it should begin with `revert:`, followed by the header of the reverted commit. In the body it should say: `This reverts commit <hash>.`, here the hash is the SHA of the commit being reverted.

## Type

Must be one of the following:

- **feat**: A new feature
- **fix**: A bug fix
- **docs**: Documentation only changes
- **style**: Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc)
- **refactor**: A code change that neither fixes a bug nor adds a feature
- **perf**: A code change that improves performance
- **test**: Adding missing tests
- **chore**: Changes to the build process or auxiliary tools and libraries such as documentation generation

### Scope

The scope could be anything specifying place of the commit change. For example `timeline`, `projects`, `users`, etc...

### Subject

The subject contains succinct description of the change:

- use the imperative, present tense: "change" not "changed" or "changes"
- don't capitalize first letter
- no dot (.) at the end

**Breaking Changes** should start with the word `BREAKING CHANGE:` with a space or two newlines. The rest of the commit message is then used for this.

#### Examples

Appears under "Features" header, pencil subheader:

```#!/text
feat(pencil): add 'graphiteWidth' option
```

Appears under "Bug Fixes" header, graphite subheader, with a link to issue #GSNP-28:

```#!/text
fix(graphite): stop graphite breaking when width < 0.1

Closes #123
```

Appears under "Performance Improvements" header, and under "Breaking Changes" with the breaking change explanation:

```#!/text
perf(pencil): remove graphiteWidth option

BREAKING CHANGE: The graphiteWidth option has been removed. The default graphite width of 10mm is always used for performance reason.
```

The following commit and commit `667ecc1` do not appear in the changelog if they are under the same release. If not, the revert commit appears under the "Reverts" header.

```#!/text
revert: feat(pencil): add 'graphiteWidth' option

This reverts commit 667ecc1654a317a13331b17617d973392f415f02.
```

A detailed explanation can be found in this [document](https://docs.google.com/document/d/1QrDFcIiPjSLDn3EL15IJygNPiHORgU1_OOAqWjiDU5Y/edit#).
