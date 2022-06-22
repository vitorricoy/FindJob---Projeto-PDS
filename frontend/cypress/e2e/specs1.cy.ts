describe('Fluxo do cliente', () => {
  it('Teste 1: Visita página', () => {
    cy.visit('http://localhost:3000/')
  })

  it('Teste 2: Cria conta do cliente', () => {
    cy.get('[data-testid="signup-button"]')
        .click()

    cy.url().should('include', '/register')

    cy.get('[data-testid="email-input"]')
        .type('cliente@email.com')
        .should('have.value', '')

    cy.get('[data-testid="password-input"]')
        .type('senha')
        .should('have.value', '')

    cy.get('[data-testid="name-input"]')
        .type('Cliente')
        .should('have.value', '')

    cy.get('[data-testid="phone-input"]')
        .type('874596123')
        .should('have.value', '')

    cy.get('[data-testid="register-button"]')
        .click()
})

  it('Teste 3: Verifica redirecionamento', () => {
    cy.url().should('include', '/home')

    cy.get('[data-testid="newjob-button"]')
      .click()
  })

  it('Teste 4: Cria novo job', () => {
    cy.get('[data-testid="title-input"]')
      .type('Job')
      .should('have.value', '')

    cy.get('[data-testid="description-input"]')
      .type('Job description')
      .should('have.value', '')
  
    cy.get('[data-testid="deadline-input"]')
      .type('13')
      .should('have.value', '')

    cy.get('[data-testid="skill-input"]')
      .type('Skill')
      .should('have.value', '')

    cy.get('[data-testid="addskill-button"]')
      .click()

    cy.get('[data-testid="Skill-text"]')

    cy.get('[data-testid="perhour-checkbox"]')
      .click()

    cy.get('[data-testid="payment-input"]')
      .type('50')
      .should('have.value', '')

    cy.get('[data-testid="createjob-button"]')
      .click()
  })

  it('Teste 5: Verifica se o job criado é exibido corretamente na listagem de jobs', () => {
    cy.url().should('include', '/jobs-list/true')

    cy.get('[data-testid="search-input"]')
      .type('Job')
      .should('have.value', '')

    cy.get('[data-testid="skills-div"]')
      .contains('Skill')

    cy.get('[data-testid="Job-button"]')
      .first().click()
  })

  it('Teste 6: Verifica se o job foi criado com os atributos corretos', () => {
    cy.url().should('include', '/client-job-view')

    cy.get('[data-testid="title-div"]')
      .contains('Job')

    cy.get('[data-testid="description-div"]')
      .contains('Job description')

    cy.get('[data-testid="price-div"]')
      .contains('R$ 50/h')

    cy.get('[data-testid="freelancers-div"]')
      .contains('Job ainda sem ofertas!')
  })

  it('Teste 7: Faz o logout', () => {
    cy.get('[data-testid="menu-button"]')
      .click()

    cy.get('[data-testid="logout-button"]')
      .click()

    cy.get('[data-testid="login-button"]')
  })

})
